using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Dashboard;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Dashboard
{
    public static class GetDistributionByAcquisitionType
    {
        public class Query : IRequest<Result<List<EdinimSeklineGoreKopekSayisiGetir>>> { }

        public class Handler(GorkemDbContext Context) : IRequestHandler<Query, Result<List<EdinimSeklineGoreKopekSayisiGetir>>>
        {
            public async Task<Result<List<EdinimSeklineGoreKopekSayisiGetir>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await Context.UT_Kopek_Kopeks
                    .GroupBy(k=>k.EdinimSekli)
                    .Select(g=> new EdinimSeklineGoreKopekSayisiGetir
                    {
                        EdinimSekli=g.Key.ToString(),
                        KopekSayisi=g.Count()
                    }).ToListAsync(cancellationToken);
                return Result<List<EdinimSeklineGoreKopekSayisiGetir>>.Success(result);
            }
        }
    }

    public class GetDistributionByAcquisitionTypeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapGet("dashboard/edinimSeklineGoreKopekSayisi", async (ISender sender) =>
            {
                var request = new GetDistributionByAcquisitionType.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.DASHBOARD);
            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
