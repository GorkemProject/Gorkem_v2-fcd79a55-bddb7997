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
                var haftalikRaporlar = await _context.UT_HaftalıkDegerlendirmeRaporuGozlemlers
                    .Where(a => a.Aktifmi && a.KursId == request.KursId)
                    .Include(a => a.Kurs)
                        .ThenInclude(a => a.KursEgitimListesi)
                    .Include(a => a.Kurs.KursEgitmenler)
                    .Include(a => a.Kurs.Kursiyerler.Where(a => a.Aktifmi))
                        .ThenInclude(a => a.Kopek)
                    .GroupBy(k => k.Hafta.ToString())
                    .Select(group => new KursunHaftalikRaporlariniGetirResponse
                    {
                        Hafta = group.Key,
                        Gozlemler = group.Select(y => new HaftalıkRaporGozlemResponse
                        {
                            KursiyerAdi = y.Kursiyer.PersonelAdi,
                            KopekAdi = y.Kursiyer.Kopek.KopekAdi,
                            Gozlem = y.Gozlemler
                        }).ToList()
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
            var mapGet = app.MapGet("kopekKurs/GetKursHaftalikRaporByKursId", async (int kursId, ISender sender) =>
              {
                  var request = new GetKursHaftalikDegerlendirmeRaporuByKursId.Query(kursId);
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
