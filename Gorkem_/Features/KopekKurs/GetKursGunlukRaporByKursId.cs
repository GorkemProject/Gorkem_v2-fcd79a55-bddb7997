using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetKursGunlukRaporByKursId
    {
        public class Query : IRequest<Result<List<KursunKursGunlukRaporlariniGetirResponse>>>
        {
            public int KursId { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }

            public Query(int kursId, int pageNumber, int pageSize)
            {
                KursId = kursId;
                PageNumber = pageNumber;
                PageSize = pageSize;
            }
        }
        internal sealed class Handler : IRequestHandler<Query, Result<List<KursunKursGunlukRaporlariniGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KursunKursGunlukRaporlariniGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var kursiyerList = await _context.UT_Kursiyer
                .Where(x=>x.Aktifmi && x.KursId.Equals(request.KursId))
                .ToListAsync(cancellationToken);

                var gunlukRaporlar = await _context.UT_KursGunlukRapors
                    .Where(a => a.Aktifmi && a.KursId == request.KursId)
                    .Include(a => a.Kurs)
                        .ThenInclude(a => a.KursEgitimListesi)
                    .Include(a => a.Kurs.KursEgitmenler)
                    .Include(a => a.Kurs.Kursiyerler)                    
                    .Include(a => a.KursGunlukRaporDersler)
                        .ThenInclude(b => b.Ders)
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)

                    .Select(k => new KursunKursGunlukRaporlariniGetirResponse
                    {
                        KursId = k.KursId,
                        KursAdi = k.Kurs.KursEgitimListesi.Name,
                        SinifAdi = k.SinifAdi,
                        T_DersTarihi = k.T_DersTarihi,
                        Dersler = k.KursGunlukRaporDersler.Select(d => d.Ders.Name).ToList(),
                        KursEgitmenler = k.Kurs.KursEgitmenler.Select(a => new KursEgitmenResponse
                        {
                            EgitmenAdi = a.AdSoyad,
                            EgitmenId = a.Id
                        }).ToList(),
                        KursKursiyer = kursiyerList
                        .Select(a => new KursKursiyerResponse
                        {
                            KursiyerAdi = a.PersonelAdi,
                            KursiyerId = a.Id
                        }).ToList()


                    }).ToListAsync(cancellationToken);

                if (gunlukRaporlar==null && !gunlukRaporlar.Any())
                {
                    return Result<List<KursunKursGunlukRaporlariniGetirResponse>>.Fail("Kursa ait bir günlük rapor bulunamadı..");
                }
                return Result<List<KursunKursGunlukRaporlariniGetirResponse>>.Success(gunlukRaporlar);
            }
        }
    }

    public class GetKursGunlukRaporByKursIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/GetKursGunlukRaporByKursId", async (int kursId, int pageNumber, int pageSize, ISender sender) =>
            {

                var request = new GetKursGunlukRaporByKursId.Query(kursId, pageNumber,pageSize);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
