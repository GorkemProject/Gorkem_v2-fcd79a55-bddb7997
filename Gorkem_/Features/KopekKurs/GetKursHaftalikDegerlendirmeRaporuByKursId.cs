using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetKursHaftalikDegerlendirmeRaporuByKursId
    {
        public class Query : IRequest<Result<List<KursunHaftalikRaporlariniGetirResponse>>>
        {
            public int KursId { get; set; }

            public Query(int kursId)
            {
                KursId = kursId;
            }
        }
        internal sealed class Handler : IRequestHandler<Query, Result<List<KursunHaftalikRaporlariniGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KursunHaftalikRaporlariniGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var haftalikRaporlar = await _context.UT_KursHaftalıkDegerlendirmeRaporus
                    .Where(a => a.Aktifmi && a.KursId == request.KursId)
                    .Include(a => a.Kurs)
                        .ThenInclude(a => a.KursEgitimListesi)
                    .Include(a => a.Kurs.KursEgitmenler)
                    .Include(a => a.Kurs.Kursiyerler)
                        .ThenInclude(a=>a.Kopek)
                    .Select(k => new KursunHaftalikRaporlariniGetirResponse
                    {
                        EgitimProgramiAdi = k.Kurs.KursEgitimListesi.Name,
                        KursDonemi = k.Kurs.Donem,
                        KursEgitmenler = k.Kurs.KursEgitmenler.Select(a => new KursEgitmenResponse
                        {
                            EgitmenAdi = a.AdSoyad,
                            EgitmenId = a.Id,
                        }).ToList(),
                       
                        KursiyerSayisi = k.Kurs.Kursiyerler.Count(),
                        KursBaslangicTarih=k.Kurs.T_KursBaslangic,
                        KursBitisTarih=k.Kurs.T_KursBitis,
                        GozlemResponse=k.HaftalıkDegerlendirmeRaporuGozlemler.Select(a=> new HaftalikRaporGozlemResponse
                        {
                            GozlemAdi=a.Gozlemler,
                            GozlemId=a.Id,
                            Kursiyer=a.Kursiyer.PersonelAdi,
                            KursiyerId=a.Kursiyer.Id,
                            KopekId=a.Kursiyer.Kopek.Id,
                            KopekAdi=a.Kursiyer.Kopek.KopekAdi
                            
                        }).ToList(),
                    }).ToListAsync();
                
                if (haftalikRaporlar == null)
                {
                    return Result<List<KursunHaftalikRaporlariniGetirResponse>>.Fail("Kursa ait bir haftalık rapor bulunamadı..");
                }
                return Result<List<KursunHaftalikRaporlariniGetirResponse>>.Success(haftalikRaporlar);
            }
        }
    }

    public class GetKursHaftalikDegerlendirmeRaporuByKursIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/GetKursHaftalikRaporByKursId", async (int kursId, ISender sender) =>
            {
                var request = new GetKursHaftalikDegerlendirmeRaporuByKursId.Query(kursId);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
                
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }


}
