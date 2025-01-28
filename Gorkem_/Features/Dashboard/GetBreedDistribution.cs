using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Dashboard;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Dashboard
{
    public static class GetBreedDistribution
    {
        public class Query : IRequest<Result<List<IrklaraGoreKopekSayisiGetirResponse>>> { }

        public class Handler(GorkemDbContext Context) : IRequestHandler<Query, Result<List<IrklaraGoreKopekSayisiGetirResponse>>>
        {
            public async Task<Result<List<IrklaraGoreKopekSayisiGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await Context.UT_Kopek_Kopeks
                    .GroupBy(k => k.Irk.Name)
                    .Select(g => new IrklaraGoreKopekSayisiGetirResponse
                    {
                        Breed = g.Key,
                        Count = g.Count()
                    }).ToListAsync(cancellationToken);
                return Result<List<IrklaraGoreKopekSayisiGetirResponse>>.Success(result);
            }
        }
    }
    public class GetBreedDistributionEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("dashboard/irklaraGoreKopekSayisi", async (ISender sender) =>
            {

                var request = new GetBreedDistribution.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.DASHBOARD);
        }
    }
}
