using Application.Common.FilterExtensions;
using Application.Common.Results;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using GorkemPagingAndFiltering.Extension;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using System.Linq.Expressions;

namespace Gorkem_.Features.Komisyon;

public record KomisyonFilterResponse(List<KomisyonGetirFilterResponse> Komisyon, Dictionary<string, List<object>> ColumnValues, int TotalCount);
public record GetKomisyonByFilterQuery(KomisyonGetirFilterRequest Request) : IRequest<Result<KomisyonFilterResponse>>;

public class GetKomisyonByFilterQueryHandler : IRequestHandler<GetKomisyonByFilterQuery, Result<KomisyonFilterResponse>>
{
    private readonly GorkemDbContext _context;

    public GetKomisyonByFilterQueryHandler(GorkemDbContext context)
    {
        _context = context;
    }

    public async Task<Result<KomisyonFilterResponse>> Handle(GetKomisyonByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = _context.UT_Komisyons
            .Where(x => x.Aktifmi)
            .Include(x => x.GorevYeri)
            .AsQueryable();

        TypeAdapterConfig<UT_Komisyon, KomisyonGetirFilterResponse>
            .NewConfig()
            .Map(dest => dest.GorevYeriId, src => src.GorevYeri.Id)
            .Map(dest => dest.GorevYeri, src => src.GorevYeri.Name);

        if (request.Request.Filters.Count > 0)
        {
            query = FilterData.Filter(query, request.Request.Filters);
        }
        if (request.Request.SortedColumn != "")
        {
            var direction = request.Request.SortDirection == "asc" ? "OrderBy" : "OrderByDescending"; //
            var param = Expression.Parameter(typeof(UT_Komisyon), "x");
            var property = Expression.Property(param, request.Request.SortedColumn);
            var lambda = Expression.Lambda(property, param);
            var exp = Expression.Call(typeof(Queryable), direction, new Type[] { typeof(UT_Komisyon), property.Type }, query.Expression, Expression.Quote(lambda));
        }
        var paged = PagedResult<UT_Komisyon>.ToPagedResponse(query, request.Request.PageNumber, 10);
        var mappedItems = paged.Items.Adapt<List<KomisyonGetirFilterResponse>>();

        var columnValues = GorkemReturning.GetUniqueValues(query, "GorevYeri");

        var response = new KomisyonFilterResponse(mappedItems, columnValues, query.Count());

        return await Result<KomisyonFilterResponse>.SuccessAsync(response);
    }
}

public class KomisyonFilterEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var mapGet = app.MapPost("komisyon/komisyonFilter", async ([FromBody] KomisyonGetirFilterRequest request, ISender sender) =>
         {
             var response = await sender.Send(new GetKomisyonByFilterQuery(request));
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
