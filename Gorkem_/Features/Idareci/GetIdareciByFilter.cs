﻿using Application.Common.FilterExtensions;
using Application.Common.Results;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Idareci;
using Gorkem_.Contracts.Kopek;
using Gorkem_.EndpointTags;
using GorkemPagingAndFiltering.Extension;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Linq.Expressions;

namespace Gorkem_.Features.Idareci;
public record IdareciFilterResponse(List<IdareciGetirFilterResponse> Idareci, Dictionary<string,List<object>> ColumnValues, int TotalCount);
public record GetIdareciByFilterQuery(IdareciGetirFilterRequest Request): IRequest<Result<IdareciFilterResponse>>;

public class GetIdareciByFilterQueryHandler : IRequestHandler<GetIdareciByFilterQuery, Result<IdareciFilterResponse>>
{
    private readonly GorkemDbContext context;

    public GetIdareciByFilterQueryHandler(GorkemDbContext context)
    {
        this.context = context;
    }

    public async Task<Result<IdareciFilterResponse>> Handle(GetIdareciByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = context.UT_AdayIdareci
            .Include(x => x.GorevYeri)
            .Include(x => x.Askerlik)
            .Include(x => x.Brans)
            .Include(x => x.Rutbe)  
            .AsQueryable();

        if (request.Request.IsIdareci)
        {
            query = query.Where(x=> context.UT_Idarecis.Any(y=>y.IdareciId.Equals(x.Id)));
        }
        else{
            query = query.Where(x=> !context.UT_Idarecis.Any(y=>y.IdareciId.Equals(x.Id)));
        }

        TypeAdapterConfig<UT_AdayIdareci, IdareciGetirFilterResponse>
            .NewConfig()
            .Map(dest => dest.KadroIl, src => src.GorevYeri.Name)
            .Map(dest => dest.Askerlik, src => src.Askerlik.Name)
            .Map(dest => dest.Brans, src => src.Brans.Name)
            .Map(dest => dest.Rutbe, src => src.Rutbe.Name);

        if (request.Request.Filters.Count >0)
        {
            query = FilterData.Filter(query, request.Request.Filters);
        }

        if (request.Request.SortedColumn != "")
        {
            var direction = request.Request.SortDirection == "asc" ? "OrderBy" : "OrderByDescending";
            var param = Expression.Parameter(typeof(UT_AdayIdareci), "x");
            var property = Expression.Property(param, request.Request.SortedColumn);
            var lambda = Expression.Lambda(property, param);
            var exp = Expression.Call(typeof(Queryable), direction, new Type[] { typeof(UT_AdayIdareci), property.Type }, query.Expression, Expression.Quote(lambda));
            query = query.Provider.CreateQuery<UT_AdayIdareci>(exp);
        }

        var paged = PagedResult<UT_AdayIdareci>.ToPagedResponse(query, request.Request.PageNumber, 10);
        var mappedItems = paged.Items.Adapt<List<IdareciGetirFilterResponse>>();

        if(request.Request.IsIdareci){
            mappedItems.ForEach(x=>{
                var kopek = context.UT_IdareciKopekleri
                .Include(y=>y.Kopek)
                .FirstOrDefault(y=>y.AdayIdareciId.Equals(x.Id) && y.Aktifmi);
                if(kopek is not null){
                x.KopekId = kopek.KopekId;
                x.Kopek = kopek.Kopek.KopekAdi;
                }
            });
        };

        var columnValues = GorkemReturning.GetUniqueValues(query, "Brans","Rutbe");

        var response = new IdareciFilterResponse(mappedItems, columnValues, query.Count());

        return await Result<IdareciFilterResponse>.SuccessAsync(response);
        
    }
}
public class IdareciFilterEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
       var mapGet= app.MapPost("idareci/idareciFilter", async ([FromBody] IdareciGetirFilterRequest request, ISender sender) =>
        {
            var response = await sender.Send(new GetIdareciByFilterQuery(request));
            if (response.Succeeded)
                return Results.Ok(response);

            return Results.BadRequest(response.Message);
        }).WithTags(EndpointConstants.IDARECI);
        if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
        {
            mapGet.RequireAuthorization();
        }
    }
}

