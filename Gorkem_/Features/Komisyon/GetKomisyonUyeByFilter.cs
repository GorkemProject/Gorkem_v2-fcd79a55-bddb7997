using Application.Common.FilterExtensions;
using Application.Common.Results;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Idareci;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using Gorkem_.Features.Idareci;
using GorkemPagingAndFiltering.Extension;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Gorkem_.Features.Komisyon;

public record KomisyonUyeFilterResponse(List<KomisyonUyeGetirFilterResponse> KomsiyonUye, Dictionary<string, List<Object>> ColumnValues, int TotalCount);
public record GetKomisyonUyeleriByFilterQuery(KomisyonUyeGetirFilterRequest Request): IRequest<Result<KomisyonUyeFilterResponse>>;

public class GetKomisyonUyeleriByFilterQueryHandler : IRequestHandler<GetKomisyonUyeleriByFilterQuery, Result<KomisyonUyeFilterResponse>>
{
    private readonly GorkemDbContext _context;

    public GetKomisyonUyeleriByFilterQueryHandler(GorkemDbContext context)
    {
        _context = context;
    }

    public async Task<Result<KomisyonUyeFilterResponse>> Handle(GetKomisyonUyeleriByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = _context.UT_KomisyonUyeleris
            .Where(x=>x.Aktifmi)
            .Include(x=>x.GorevYeri)
            .AsQueryable();

        TypeAdapterConfig<UT_KomisyonUyeleri, KomisyonUyeleriGetirResponse>
            .NewConfig()
            .Map(dest => dest.GorevYeriId, src => src.GorevYeri.Id)
            .Map(dest => dest.GorevYeriName, src => src.GorevYeri.Name)
            .Map(dest => dest.Id, src=>src.Id);

        if (request.Request.Filters.Count>0)
        {
            query = FilterData.Filter(query, request.Request.Filters);
        }
        if (request.Request.SortedColumn !="")
        {
            var direction = request.Request.SortDirection == "asc" ? "OrderBy" : "OrderByDescending";
            var param = Expression.Parameter(typeof(UT_KomisyonUyeleri), "x");
            var property = Expression.Property(param, request.Request.SortedColumn);
            var lambda = Expression.Lambda(property, param);
            var exp = Expression.Call(typeof(Queryable), direction, new Type[] { typeof(UT_KomisyonUyeleri), property.Type }, query.Expression, Expression.Quote(lambda));
        }
        var paged = PagedResult<UT_KomisyonUyeleri>.ToPagedResponse(query, request.Request.PageNumber, 10);
        var mappedItems = paged.Items.Adapt<List<KomisyonUyeGetirFilterResponse>>();

 

        var columnValues = GorkemReturning.GetUniqueValues(query, "GorevYeri");

        var response = new KomisyonUyeFilterResponse(mappedItems, columnValues, query.Count());

        return await Result<KomisyonUyeFilterResponse>.SuccessAsync(response);
    }
}
public class KomisyonUyeleriFilterEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
       var mapGet= app.MapPost("komisyonuye/komisyonUyeFilter", async ([FromBody] KomisyonUyeGetirFilterRequest request, ISender sender) =>
        {
            var response = await sender.Send(new GetKomisyonUyeleriByFilterQuery(request));
            if (response.Succeeded)
                return Results.Ok(response);

            return Results.BadRequest(response);

        }).WithTags(EndpointConstants.KOMISYON);

        if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
        {
            mapGet.RequireAuthorization();
        }
    }
}