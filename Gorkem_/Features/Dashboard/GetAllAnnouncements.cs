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
    public static class GetAllAnnouncements
    {
        public class Query : IRequest<Result<List<DuyurulariGetirResponse>>> { }

        public class Hnadler(GorkemDbContext Context) : IRequestHandler<Query, Result<List<DuyurulariGetirResponse>>>
        {
            public async Task<Result<List<DuyurulariGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var duyurular = await Context.UT_Duyurulars
                    .Where(a => a.Aktifmi)
                    .Select(a => new DuyurulariGetirResponse
                    {
                        Baslik = a.Baslik,
                        Icerik = a.Icerik,
                        Tarih = a.T_Aktif.Date
                    }).ToListAsync(cancellationToken);

                return Result<List<DuyurulariGetirResponse>>.Success(duyurular);
            }
        }

    }

    public class GetAllAnnouncementsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapGet("dashboard/GetAllAnnouncements", async (ISender sender) =>
            {
                var request = new GetAllAnnouncements.Query();
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
