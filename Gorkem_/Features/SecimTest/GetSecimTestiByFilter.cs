using Application.Common.FilterExtensions;
using Application.Common.Results;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.Contracts.SecimTest;
using Gorkem_.EndpointTags;
using Gorkem_.Enums;
using Gorkem_.Features.Komisyon;
using GorkemPagingAndFiltering.Extension;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Gorkem_.Features.SecimTest;

public record SecimTestiFilterResponse(List<SecimTestiGetirFilterResponse> SecimTesti, Dictionary<string, List<object>> ColumnValues, int TotalCount);
public record GetSecimTestiByFilterQuery(SecimTestiGetirFilterRequest Request) : IRequest<Result<SecimTestiFilterResponse>>;

public class GetSecimTestiByFilterQueryHandler : IRequestHandler<GetSecimTestiByFilterQuery, Result<SecimTestiFilterResponse>>
{
    private readonly GorkemDbContext _context;

    public GetSecimTestiByFilterQueryHandler(GorkemDbContext context)
    {
        _context = context;
    }

    public async Task<Result<SecimTestiFilterResponse>> Handle(GetSecimTestiByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = _context.UT_SecimTests
            .Where(x => x.Aktifmi)
            .Include(x=>x.SinavYeri)
            .AsQueryable();

        TypeAdapterConfig<UT_SecimTest, SecimTestiGetirFilterResponse>
            .NewConfig()
            .Map(dest => dest.KopekId, src => src.KopekId)
            .Map(dest => dest.SecimTestId, src => src.SecimTestId)
            .Map(dest => dest.SinavYeriId, src => src.SinavYeri.Id) 
            .Map(dest => dest.Tarih, src => src.Tarih)
            .Map(dest => dest.SecimTestBrans, src => src.SecimTestBrans)
            .Map(dest => dest.ToplamPuan, src => src.ToplamPuan);

        if (request.Request.Filters.Count>0)
        {
            query = FilterData.Filter(query, request.Request.Filters);
        }

        if (request.Request.SortedColumn != "")
        {
            var direction = request.Request.SortDirection == "asc" ? "OrderBy" : "OrderByDescending"; 
            var param = Expression.Parameter(typeof(UT_SecimTest), "x");
            var property = Expression.Property(param, request.Request.SortedColumn);
            var lambda = Expression.Lambda(property, param);
            var exp = Expression.Call(typeof(Queryable), direction, new Type[] { typeof(UT_SecimTest), property.Type }, query.Expression, Expression.Quote(lambda));
        }

        var paged = PagedResult<UT_SecimTest>.ToPagedResponse(query, request.Request.PageNumber, 10);
        var mappedItems = paged.Items.Adapt<List<SecimTestiGetirFilterResponse>>();

        var columnValues = GorkemReturning.GetUniqueValues(query, "GorevYeri");

        var response = new SecimTestiFilterResponse(mappedItems, columnValues, query.Count());

        return await Result<SecimTestiFilterResponse>.SuccessAsync(response);
    }
}

public class SecimTestiFilterEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("secimTesti/SecimTestiFilter", async ([FromBody] SecimTestiGetirFilterRequest request, ISender sender) =>
        {
            var response = await sender.Send(new GetSecimTestiByFilterQuery(request));
            if (response.Succeeded)
                return Results.Ok(response);
            return Results.BadRequest(response);


        }).WithTags(EndpointConstants.SECİMTEST);
    }
}
