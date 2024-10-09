using Application.Common.FilterExtensions;
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
public record IdareciFilterResponse(List<IdareciGetirFilterResponse> Idareci, Dictionary<string,List<object>> ColumnValues, int TotalAccount);
public record GetIdareciByFilterQuery(IdareciGetirFilterRequest Request): IRequest<Result<IdareciFilterResponse>>;

public class GetIdareciByFilterQueryHandler : IRequestHandler<GetIdareciByFilterQuery, Result<IdareciFilterResponse>>
{
    private readonly GorkemDbContext context;
    public async Task<Result<IdareciFilterResponse>> Handle(GetIdareciByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = context.UT_Idarecis
            .Include(x => x.KadroIl)
            .Include(x => x.Askerlik)
            .Include(x => x.Brans)
            .Include(x => x.Rutbe)
            .AsQueryable();

        TypeAdapterConfig<UT_Idareci, IdareciGetirFilterResponse>
            .NewConfig()
            .Map(dest => dest.Birim, src => src.KadroIl.Name)
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
            var param = Expression.Parameter(typeof(UT_Idareci), "x");
            var property = Expression.Property(param, request.Request.SortedColumn);
            var lambda = Expression.Lambda(property, param);
            var exp = Expression.Call(typeof(Queryable), direction, new Type[] { typeof(UT_Idareci), property.Type }, query.Expression, Expression.Quote(lambda));
        }

        var paged = PagedResult<UT_Idareci>.ToPagedResponse(query, request.Request.PageNumber, 10);
        var mappedItems = paged.Items.Adapt<List<IdareciGetirFilterResponse>>();
        var columnValues = GorkemReturning.GetUniqueValues(query, "Birim");
        var response = new IdareciFilterResponse(mappedItems, columnValues, query.Count());
        return await Result<IdareciFilterResponse>.SuccessAsync(response);
        
    }
}
public class IdareciFilterEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("idareci/idareciFilter", async ([FromBody] IdareciGetirFilterRequest request, ISender sender) =>
        {
            var response = await sender.Send(new GetIdareciByFilterQuery(request));
            if (response.Succeeded)
                return Results.Ok(response);

            return Results.BadRequest(response.Message);
        }).WithTags(EndpointConstants.IDARECI);
    }
}

