using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.SecimTest;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Drawing.Text;

namespace Gorkem_.Features.SecimTest
{
    public static class ListSecimTest
    {
        public record Query(SecimTestiListeleRequest Request) : IRequest<Result<List<SecimTestResponse>>>;

        internal sealed class Handler : IRequestHandler<Query, Result<List<SecimTestResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<SecimTestResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.UT_SecimTests
                    .Include(x=>x.Kopek)
                    .Include(x=>x.Komisyon)
                    .Include(x=>x.SecimTest)
                    .AsQueryable();

                //Köpeğe göre filtreleme
                if (request.Request.KopekId != 0)
                {
                    query = query.Where(x => x.KopekId == request.Request.KopekId);
                }

                //KomisyonId Göre Filtreleme
                if (request.Request.KomisyonId != 0)
                {
                    query = query.Where(x => x.KomisyonId == request.Request.KomisyonId);
                }

                //Tarihe Göre Sıralama
                if (request.Request.BaslangicTarih.HasValue && request.Request.BitisTarihi.HasValue)
                {
                    query = query.Where(x => x.T_Aktif >= request.Request.BaslangicTarih && x.Tarih <= request.Request.BitisTarihi);
                }

                //Sınav Yerine Göre Filtreleme
                if (request.Request.SinavYeriId != 0)
                {
                    query = query.Where(x => x.SinavYeriId == request.Request.SinavYeriId);

                }

                //Yapılan Teste Göre Filtreleme
                if (request.Request.SecimTestId != 0)
                {
                    query = query.Where(x => x.SecimTestId == request.Request.SecimTestId);
                }

                //Köpeğin Aldığı Puana Göre Filtreleme
                if (request.Request.PuanAltSinir.HasValue && request.Request.PuanUstSinir.HasValue)
                {
                    query = query.Where(x => x.ToplamPuan >= request.Request.PuanAltSinir && x.ToplamPuan <= request.Request.PuanUstSinir);
                }

                //Köpek Irkına Göre Filtreleme
                if (request.Request.IrkId != 0)
                {
                    query = query.Where(x => x.Kopek.IrkId == request.Request.IrkId.Value);
                }

                //Köpek Cinsiyetine Göre Filtreleme
                if (request.Request.Cinsiyet != 0)
                {
                    query = query.Where(x => x.Kopek.Cinsiyet == request.Request.Cinsiyet.Value);
                }


                var secimTestleri = await query.Select(x => new SecimTestResponse
                {
                    Degerlendirme = x.Degerlendirme,
                    Havlama = x.Havlama,
                    Id = x.Id,
                    KomisyonId = x.KomisyonId,
                    KomisyonName = x.Komisyon.KomisyonAdi,
                    KopekCinsiyet = x.Kopek.Cinsiyet,
                    KopekId = x.Kopek.Id,
                    KopekName = x.Kopek.KopekAdi,
                    SecimTestBrans = x.SecimTestBrans,
                    SecimTestId = x.SecimTestId,
                    SecimTestName = x.SecimTest.Name,
                    SinavYeriId = x.SinavYeriId,
                    SinavYeriName = x.SinavYeri.Name,
                    Tarih = x.Tarih,
                    TepkiSekli = x.TepkiSekli,
                    ToplamPuan = x.ToplamPuan
                }).ToListAsync(cancellationToken);

                return Result<List<SecimTestResponse>>.Success(secimTestleri);
            }
        }
    }

    public class ListSecimTestEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("secimTesti/ListSecimTesti", async ([FromBody] SecimTestiListeleRequest model, ISender sender) =>
            {
                var query = new ListSecimTest.Query(model);
                var response = await sender.Send(query);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.SECİMTEST);
        }
    }
}
