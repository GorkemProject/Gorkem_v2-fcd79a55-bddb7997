using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Dashboard;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Dashboard
{
    public static class GetDistributionByBranch
    {
        public class Query : IRequest<Result<List<BransaGoreKopekSayisiGetir>>> { }

        public class Handler(GorkemDbContext Context) : IRequestHandler<Query, Result<List<BransaGoreKopekSayisiGetir>>>
        {
            public async Task<Result<List<BransaGoreKopekSayisiGetir>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await Context.UT_Kopek_Kopeks
                    .GroupBy(a => a.Brans.Name)
                    .Select(g => new BransaGoreKopekSayisiGetir
                    {
                        Brans = g.Key,
                        Sayi = g.Count()
                    }).ToListAsync(cancellationToken);
                return Result<List<BransaGoreKopekSayisiGetir>>.Success(result);
            }
        }
    }

    public class GetDistributionByBranchEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("dashboard/branslaraGoreKopekSayisi", async (ISender sender) =>
            {
                var request = new GetDistributionByBranch.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.DASHBOARD);
        }
    }
}
