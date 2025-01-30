using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Dashboard;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Dashboard
{
    public static class GetAgeAndGenderDistribution
    {

        public class Query : IRequest<Result<List<YasVeCinsiyeteGoreKopekSayisiGetirResponse>>> { }

        public class Handler(GorkemDbContext Context) : IRequestHandler<Query, Result<List<YasVeCinsiyeteGoreKopekSayisiGetirResponse>>>
        {
            public async Task<Result<List<YasVeCinsiyeteGoreKopekSayisiGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                // Köpeklerin doğum tarihlerini ve cinsiyetlerini veritabanından çek
                var kopekler = await Context.UT_Kopek_Kopeks
                    .Select(k => new
                    {
                        k.DogumTarihi,
                        k.Cinsiyet
                    })
                    .ToListAsync(cancellationToken);

                // Doğum tarihlerini kullanarak yaş hesapla ve grupla
                var result = kopekler
                    .Select(k => new
                    {
                        Yas = YasHesapla(k.DogumTarihi), // Uygulama tarafında yaş hesapla
                        Cinsiyet = k.Cinsiyet
                    })
                    .GroupBy(k => new
                    {
                        YasGrubu = GetYasGrubu(k.Yas), // Yaş grubunu belirle
                        Cinsiyet = k.Cinsiyet
                    })
                    .Select(g => new
                    {
                        g.Key.YasGrubu,
                        g.Key.Cinsiyet,
                        Count = g.Count()
                    })
                    .ToList();

                // Yaş gruplarına göre cinsiyet dağılımını hesapla
                var groupedResult = result
                    .GroupBy(r => r.YasGrubu)
                    .Select(g => new YasVeCinsiyeteGoreKopekSayisiGetirResponse
                    {
                        YasGrubu = g.Key,
                        ErkekSayisi = g.Where(x => x.Cinsiyet.ToString() == "Erkek").Sum(x => x.Count),
                        DisiSayisi = g.Where(x => x.Cinsiyet.ToString() == "Disi").Sum(x => x.Count)
                    })
                    .ToList();

                return Result<List<YasVeCinsiyeteGoreKopekSayisiGetirResponse>>.Success(groupedResult);
            }

            // Doğum tarihini kullanarak yaş hesapla
            private int YasHesapla(DateTime dogumTarihi)
            {
                var bugun = DateTime.Today;
                var yas = bugun.Year - dogumTarihi.Year;

                // Eğer doğum günü henüz gelmemişse yaşını bir azalt
                if (dogumTarihi.Date > bugun.AddYears(-yas))
                    yas--;

                return yas;
            }

            // Yaş grubunu belirle
            private string GetYasGrubu(int yas)
            {
                if (yas == 0) return "0-1";
                if (yas == 1) return "1-2";
                if (yas == 2) return "2-3";
                if (yas == 3) return "3-4";
                if (yas == 4) return "4-5";
                return "5+";
            }
        }
    }

    public class GetAgeAndGenderDistributionEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapGet("dashboard/yasveCinsiyeteGoreKopekSayisi", async (ISender sender) =>
            {
                var request = new GetAgeAndGenderDistribution.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);


            }).WithTags(EndpointConstants.DASHBOARD);
            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }

        }
    }
}
