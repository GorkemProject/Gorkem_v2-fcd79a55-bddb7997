using System.Drawing.Text;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using Gorkem_.Features.Komisyon;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetKopekVeKursiyerDegerlendirmeFormuKursId
    {

        public class Query : IRequest<Result<List<KursiyerKopekDegerlendirmeResponse>>>
        {
            public int KursId { get; set; }

            public Query(int kursId)
            {
                KursId = kursId;
            }
        }



        internal sealed class Handler : IRequestHandler<Query, Result<List<KursiyerKopekDegerlendirmeResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KursiyerKopekDegerlendirmeResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aaa = _context.UT_KursDegerlendirmeCevap
                    .Include(c => c.Kursiyer)
                        .ThenInclude(k => k.Kopek).ToList();


                var kopekVeKursiyerDegerlendirme = await _context.UT_KursDegerlendirmeCevap
                    .Include(c => c.Kursiyer)

                    .Where(a => a.KursId == request.KursId && a.Aktifmi && a.Kursiyer.Aktifmi)
                    .GroupBy(a => a.Kursiyer) // Kursiyer bazında gruplama
                    .Select(g => new KursiyerKopekDegerlendirmeResponse
                    {
                        KopekAdi = _context.UT_Kopek_Kopeks.FirstOrDefault(a => a.Id == g.Key.KopekId).KopekAdi,
                        KopekCip = _context.UT_Kopek_Kopeks.FirstOrDefault(a => a.Id == g.Key.KopekId).CipNumarasi,
                        KopekDegerlendirmeCevaplar = g
                            .Where(c => c.DegerlendirmeTuru == 1) // Köpek değerlendirme türü
                            .Select(c => new DegerlendirmeCevapResponse
                            {
                                SoruAdi = c.DegerlendirmeSoru.Name,
                                AracCevapMax = c.DegerlendirmeSoru.MaxPuan,
                                KapaliAlanCevapMax = c.DegerlendirmeSoru.MaxPuan,
                                TasinabilirEsyaCevapMax = c.DegerlendirmeSoru.MaxPuan,
                                AracCevap = c.AracPuan,
                                KapaliAlanCevap = c.KapaliAlanPuan,
                                TasinabilirEsyaCevap = c.TasinabilirEsyaPuan
                            }).ToList(),
                        PersonelAdi = g.Key.PersonelAdi,
                        PersonelSicil = g.Key.Sicil,
                        PersonelDegerlendirmeCevaplar = g
                            .Where(c => c.DegerlendirmeTuru == 2) // Personel değerlendirme türü
                            .Select(c => new DegerlendirmeCevapResponse
                            {
                                SoruAdi = c.DegerlendirmeSoru.Name,
                                AracCevapMax = c.DegerlendirmeSoru.MaxPuan,
                                KapaliAlanCevapMax = c.DegerlendirmeSoru.MaxPuan,
                                TasinabilirEsyaCevapMax = c.DegerlendirmeSoru.MaxPuan,
                                AracCevap = c.AracPuan,
                                KapaliAlanCevap = c.KapaliAlanPuan,
                                TasinabilirEsyaCevap = c.TasinabilirEsyaPuan
                            }).ToList()
                    }).ToListAsync();
                return Result<List<KursiyerKopekDegerlendirmeResponse>>.Success(kopekVeKursiyerDegerlendirme);


            }
        }
    }

    public class GetKopekVeKursiyerDegerlendirmeFormuByKursIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapGet("kopekKurs/GetKopekVeKursiyerDegerlendirmeFormuKursiyerKursId", async (int KursId, ISender sender) =>
             {
                 var request = new GetKopekVeKursiyerDegerlendirmeFormuKursId.Query(KursId);
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
