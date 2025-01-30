using System.Drawing.Text;
using System.Linq.Expressions;
using Application.Common.FilterExtensions;
using Application.Common.Results;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Kopek;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using Gorkem_.Features.Kopek;
using GorkemPagingAndFiltering.Extension;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs;

public record KopekKursFilterResponse(List<KopekKursGetirFilterResponse> KopekKurs, Dictionary<string, List<object>> ColumnValues, int TotalCount);
public record GetKopekKursByFilterQuery(KopekKursGetirFilterRequest Request) : IRequest<Result<KopekKursFilterResponse>>;

public class GetKopekKursByFilterQueryHandler : IRequestHandler<GetKopekKursByFilterQuery, Result<KopekKursFilterResponse>>
{
    private readonly GorkemDbContext _context;

    public GetKopekKursByFilterQueryHandler(GorkemDbContext context)
    {
        _context = context;
    }

    public async Task<Result<KopekKursFilterResponse>> Handle(GetKopekKursByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = _context.UT_Kurs
        .Include(x => x.Kursiyerler)
        .Include(x => x.KursYeri)
        .Include((x => x.KursEgitimListesi))
        .Include(x => x.KursEgitmenler)
        .AsQueryable();

        TypeAdapterConfig<UT_Kurs, KopekKursGetirFilterResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.KursYeri, src => src.KursYeri.Name)
            .Map(dest => dest.KursEgitimListesi, src => src.KursEgitimListesi.Name);


        if (request.Request.Filters.Count > 0)
        {
            query = FilterData.Filter(query, request.Request.Filters);

        }
        if (request.Request.SortedColumn != "")
        {
            var direction = request.Request.SortDirection == "asc" ? "OrderBy" : "OrderByDescending";
            var param = Expression.Parameter(typeof(UT_Kurs), "x");
            var property = Expression.Property(param, request.Request.SortedColumn);
            var lambda = Expression.Lambda(property, param);
            var exp = Expression.Call(typeof(Queryable), direction, new Type[] { typeof(UT_Kurs), property.Type }, query.Expression, Expression.Quote(lambda));
            query = query.Provider.CreateQuery<UT_Kurs>(exp);
        }

        var paged = PagedResult<UT_Kurs>.ToPagedResponse(query, request.Request.PageNumber, 10);

        var mappedItems = paged.Items.Adapt<List<KopekKursGetirFilterResponse>>();

        var columnValues = GorkemReturning.GetUniqueValues(query, "NihaiKanaat");

        var response = new KopekKursFilterResponse(mappedItems, columnValues, query.Count());

        return await Result<KopekKursFilterResponse>.SuccessAsync(response);


    }

}

public class KopekKursFilterEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var mapGet = app.MapPost("kopekKurs/GetKopekKursFilter", async ([FromBody] KopekKursGetirFilterRequest model, ISender sender) =>
          {
              var request = new GetKopekKursByFilterQuery(model);
              var response = await sender.Send(request);

              if (response.Succeeded)
                  return Results.Ok(response);
              return Results.BadRequest(response);
          }).WithTags(EndpointConstants.KOPEKKURS);
        if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
        {
            mapGet.RequireAuthorization();
        }
    }
}