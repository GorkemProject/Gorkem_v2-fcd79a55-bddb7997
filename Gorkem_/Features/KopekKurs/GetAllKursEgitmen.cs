using System.Configuration;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetAllKursEgitmen
    {
        public class Query : IRequest<Result<List<KursEgitmenGetirResponse>>>
        {

        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KursEgitmenGetirResponse>>>
        {
            public async Task<Result<List<KursEgitmenGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifEgitmenler = await Context.UT_KursEgitmenler
                    .Where(a => a.Aktifmi)
                    .Include(a => a.Birim)
                    .Include(a => a.Rutbe)
                    .Select(a => new KursEgitmenGetirResponse
                    {
                        Id = a.Id,
                        AdSoyad = a.AdSoyad,
                        BirimId = a.BirimId,
                        Birim = a.Birim.Adi,
                        RutbeId = a.RutbeId,
                        Rutbe = a.Rutbe.Name,
                        Sicil = a.Sicil

                    }).ToListAsync(cancellationToken);
                return Result<List<KursEgitmenGetirResponse>>.Success(aktifEgitmenler);

            }
        }
    }

    public class GetAllKursEgitmenEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapGet("kopekKurs/GetAllKursEgitmen", async (ISender sender) =>
             {
                 var request = new GetAllKursEgitmen.Query();
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
}
