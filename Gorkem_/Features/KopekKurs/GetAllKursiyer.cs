using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetAllKursiyer
    {
        public class Query : IRequest<Result<List<KursiyerGetirResponse>>>
        {

        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KursiyerGetirResponse>>>
        {
            public async Task<Result<List<KursiyerGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifKursiyerler = await Context.UT_Kursiyer
                    .Where(a => a.Aktifmi)
                    .Include(a=>a.Kopek)
                    .Include(a=>a.Kurs)

                    .Select(kursiyer => new KursiyerGetirResponse
                    {
                        CipNumarası=kursiyer.CipNumarası,
                        KopekName=kursiyer.Kopek.KopekAdi,
                        KursDonem=kursiyer.Kurs.Donem,
                        KursAdi =kursiyer.Kurs.KursEgitimListesi.Name,
                        Sicil=kursiyer.Sicil,
                        PersonelAdi=kursiyer.PersonelAdi
                        
                    }).ToListAsync(cancellationToken);


                return Result<List<KursiyerGetirResponse>>.Success(aktifKursiyerler);
            }
        }
    }
    public class GetAllKursiyerEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
          var mapGet=  app.MapGet("kopekKurs/GetAllKursiyerAndKopek", async (ISender sender) =>
            {
                var request =new GetAllKursiyer.Query();
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
