using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetKursiyerBySicil
    {
        public class Query : IRequest<Result<List<SicileGoreKursiyerGetirResponse>>>
        {
            public int Sicil { get; set; }
            public Query(int sicil)
            {
                Sicil = sicil;
            }
        }

        internal sealed class Handler : IRequestHandler<Query, Result<List<SicileGoreKursiyerGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<SicileGoreKursiyerGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var kursiyer = await _context.UT_Kursiyer
                    .Include(a => a.Kopek)
                    .Where(k => k.Sicil == request.Sicil && k.Aktifmi)
                    .Select(k => new SicileGoreKursiyerGetirResponse
                    {
                        AdiSoyadi = k.PersonelAdi,
                        Sicil = k.Sicil,
                        Bransi = k.Kopek.Brans.Name,
                        CipNumarasi = k.Kopek.CipNumarasi,
                        DogumTarihi = k.Kopek.DogumTarihi,
                        KopekAdi = k.Kopek.KopekAdi,
                        KadroIl = k.Kopek.KadroIl.Name,



                    }).ToListAsync(cancellationToken);
                if (kursiyer == null)
                {
                    return Result<List<SicileGoreKursiyerGetirResponse>>.Fail("Sicile ait kursiyer bulunamadı.");
                }
                return Result<List<SicileGoreKursiyerGetirResponse>>.Success(kursiyer);

            }
        }

    }
    public class GetKursiyerBySicilEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapGet("kopekKurs/GetKursiyerBySicil", async (int sicil, ISender sender) =>
              {
                  var request = new GetKursiyerBySicil.Query(sicil);
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
