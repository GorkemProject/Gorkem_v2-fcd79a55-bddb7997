using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.SecimTest;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gorkem_.Features.SecimTest
{
    public static class ListSecimTest
    {
        // Query parametresi ile filtreleme yapılacak request tipi
        public record Query(SecimTestiListeleRequest Request) : IRequest<Result<SecimTestPaginationResponse>>;

        internal sealed class Handler : IRequestHandler<Query, Result<SecimTestPaginationResponse>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<SecimTestPaginationResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.UT_SecimTests
                    .Include(x => x.Kopek)
                    .Include(x => x.Komisyon)
                    .Include(x => x.SecimTest)
                    .AsQueryable();

                // Köpeğe göre filtreleme
                if (request.Request.KopekId != 0)
                {
                    query = query.Where(x => x.KopekId == request.Request.KopekId);
                }

                // KomisyonId'ye göre filtreleme
                if (request.Request.KomisyonId != 0)
                {
                    query = query.Where(x => x.KomisyonId == request.Request.KomisyonId);
                }

                // Tarihe göre filtreleme
                if (request.Request.BaslangicTarih.HasValue && request.Request.BitisTarihi.HasValue)
                {
                    query = query.Where(x => x.T_Aktif >= request.Request.BaslangicTarih && x.Tarih <= request.Request.BitisTarihi);
                }

                // Sinav Yerine göre filtreleme
                if (request.Request.SinavYeriId != 0)
                {
                    query = query.Where(x => x.SinavYeriId == request.Request.SinavYeriId);
                }

                // Yapılan teste göre filtreleme
                if (request.Request.SecimTestId != 0)
                {
                    query = query.Where(x => x.SecimTestId == request.Request.SecimTestId);
                }

                // Köpeğin aldığı puana göre filtreleme
                if (request.Request.PuanAltSinir.HasValue && request.Request.PuanUstSinir.HasValue)
                {
                    query = query.Where(x => x.ToplamPuan >= request.Request.PuanAltSinir && x.ToplamPuan <= request.Request.PuanUstSinir);
                }

                // Köpek ırkına göre filtreleme
                if (request.Request.IrkId != 0)
                {
                    query = query.Where(x => x.Kopek.IrkId == request.Request.IrkId.Value);
                }

                // Köpek cinsiyetine göre filtreleme
                if (request.Request.Cinsiyet != 0)
                {
                    query = query.Where(x => x.Kopek.Cinsiyet == request.Request.Cinsiyet.Value);
                }

                //Sıralama işlemi
                if (!string.IsNullOrEmpty(request.Request.SortBy))
                {
                    var sortBy = request.Request.SortBy.ToLower();
                    if(sortBy == "tarih")
                    {
                        query = request.Request.IsAscending ? query.OrderBy(x=>x.Tarih) : query.OrderByDescending(x => x.Tarih);
                    }
                    else if (sortBy == "toplampuan")
                    {
                        query = request.Request.IsAscending ? query.OrderBy(x => x.ToplamPuan) : query.OrderByDescending(x => x.ToplamPuan);
                    }
                    else if (sortBy == "kopekname")
                    {
                        query = request.Request.IsAscending ? query.OrderBy(x => x.Kopek.KopekAdi) : query.OrderByDescending(x => x.Kopek.KopekAdi);
                    }
                    else if (sortBy == "komisyonname")
                    {
                        query = request.Request.IsAscending ? query.OrderBy(x => x.Komisyon.KomisyonAdi) : query.OrderByDescending(x => x.Komisyon.KomisyonAdi);
                    }
                }


                // Toplam sayıyı hesapla
                var totalCount = await query.CountAsync(cancellationToken);

                // Sayfa verilerini al
                var secimTestleri = await query
                    .Skip((request.Request.PageNumber - 1) * request.Request.PageSize)
                    .Take(request.Request.PageSize)
                    .Select(x => new SecimTestResponse
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
                    })
                    .ToListAsync(cancellationToken);

                // Pagination bilgileri ile birlikte yanıtı oluştur
                var response = new SecimTestPaginationResponse
                {
                    TotalCount = totalCount,
                    PageNumber = request.Request.PageNumber,
                    PageSize = request.Request.PageSize,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)request.Request.PageSize),
                    SecimTestler = secimTestleri
                };

                return Result<SecimTestPaginationResponse>.Success(response);
            }
        }
    }

    public class ListSecimTestEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapPost("secimTesti/ListSecimTesti", async ([FromBody] SecimTestiListeleRequest model, ISender sender) =>
            {
                var query = new ListSecimTest.Query(model);
                var response = await sender.Send(query);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.SECİMTEST);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
