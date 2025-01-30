using System.Drawing.Text;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Dashboard;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Gorkem_.Features.Dashboard
{
    public static class GetTodayBornDogs
    {

        public record Query : IRequest<Result<List<BugunDoganKopeklerResponse>>>
        {

        }

        internal sealed class Handler(GorkemDbContext Context) : IRequestHandler<Query, Result<List<BugunDoganKopeklerResponse>>>
        {
            public async Task<Result<List<BugunDoganKopeklerResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
               var today = DateTime.UtcNow.Date;

                var bugunDoganKopekler = await Context.UT_Kopek_Kopeks
                    .Where(k => k.DogumTarihi.Date == today)
                    .Select(k=> new BugunDoganKopeklerResponse
                    {
                        KopekAdi=k.KopekAdi,
                        KopekResim=k.ProfileImage
                    })
                    .ToListAsync(cancellationToken);

                if (bugunDoganKopekler is null || !bugunDoganKopekler.Any())
                {
                    return await Result<List<BugunDoganKopeklerResponse>>.FailAsync("Bugün doğan köpek bulunamadı.");
                }

                return await Result<List<BugunDoganKopeklerResponse>>.SuccessAsync(bugunDoganKopekler);
            }
        }
    }

    public class GetTodayBornKopeklerEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapGet("dashboard/GetTodayBornDogs", async (ISender sender) =>
            {
                var request = new GetTodayBornDogs.Query();
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
