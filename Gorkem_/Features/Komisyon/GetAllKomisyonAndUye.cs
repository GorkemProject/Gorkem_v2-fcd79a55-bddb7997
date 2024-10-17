using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace Gorkem_.Features.Komisyon
{
    public static class GetAllKomisyonAndUye
    {
        public class Query : IRequest<Result<TumKomisyonlarVeUyelerResponse>>
        {

        }

        internal sealed class Handler : IRequestHandler<Query, Result<TumKomisyonlarVeUyelerResponse>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<TumKomisyonlarVeUyelerResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var komisyonlar =await _context.UT_Komisyons
                    .Include(k=>k.KomisyonUyeleri)
                    .ToListAsync(cancellationToken);

                var response = new TumKomisyonlarVeUyelerResponse
                {
                    Komisyonlar = komisyonlar.Select(k => new KomisyonVeUyeleriResponse
                    {
                        KomisyonAdi = k.KomisyonAdi,
                        Uyeler = k.KomisyonUyeleri.Select(u => new KomisyonUyeResponse
                        {
                            AdSoyad = u.AdSoyad,
                            CepTelefonu = u.CepTelefonu,
                            GorevUnvani = u.GorevUnvani,
                            GorevYeri = u.GorevYeri,
                            Sicil = u.Sicil
                        }).ToList()
                    }).ToList()
                };

                return Result<TumKomisyonlarVeUyelerResponse>.Success(response);
            }
        }
    }

    public class GetTumKomisyonlarAndUyeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("tumkomisyonlarveuyeler", async (ISender sender) =>
            {
                var request = new GetAllKomisyonAndUye.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response.Message);
            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
