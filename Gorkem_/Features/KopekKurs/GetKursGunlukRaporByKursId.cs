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

            public Query(int kursId)
            {
                KursId = kursId;
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
                var gunlukRaporlar = await _context.UT_KursGunlukRapors
                    .Where(a => a.Aktifmi && a.KursId == request.KursId)
                    .Include(a => a.Kurs)
                        .ThenInclude(a => a.KursEgitimListesi)
                    .Include(a => a.KGRMufredatlar)
                        .ThenInclude(a => a.Mufredat)
                    .Include(a=>a.Kurs.KursEgitmenler)
                    .Include(a=>a.Kurs.Kursiyerler)

                    .Select(k => new KursunKursGunlukRaporlariniGetirResponse
                    {
                        KursId = k.KursId,
                        KursAdi = k.Kurs.KursEgitimListesi.Name,
                        SinifAdi = k.SinifAdi,
                        T_DersTarihi = k.T_DersTarihi,
                        KGRMufredatlar = k.KGRMufredatlar.Select(a => new KGRMufredatResponse
                        {
                            MufredatAdi = a.Mufredat.Name,
                            MufredatId = a.MufredatId
                        }).ToList(),
                        KursEgitmenler=k.Kurs.KursEgitmenler.Select(a=> new KursEgitmenResponse
                        {
                            EgitmenAdi=a.AdSoyad,
                            EgitmenId=a.Id
                        }).ToList(),
                        KursKursiyer=k.Kurs.Kursiyerler.Select(a=>new KursKursiyerResponse
                        {
                            KursiyerAdi=a.Idareci.AdSoyad,
                            KursiyerId=a.IdareciId
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
            app.MapPost("kopekKurs/GetKursGunlukRaporByKursId", async (int kursId, ISender sender) =>
            {

                var request = new GetKursGunlukRaporByKursId.Query(kursId);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
