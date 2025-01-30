using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Dashboard;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Dashboard
{
    public static class GetDofOfTheMounth
    {
        public class Query : IRequest<Result<List<AyinKopeginiGetirResponse>>> { }


        internal sealed record Handler(GorkemDbContext Context) : IRequestHandler<Query, Result<List<AyinKopeginiGetirResponse>>>
        {
            public async Task<Result<List<AyinKopeginiGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {


                var ayinKopegi = await Context.UT_AyinKopegis
                    .Where(a => a.Aktifmi)
                    .Include(a => a.Kopek)
                        .ThenInclude(k => k.Birim) // Köpeğin görev yerini almak için
                    .Include(a => a.Kopek.Idareci) // Köpeğin idarecilerini getiriyoruz
                        .ThenInclude(i => i.AdayIdareci) // İlgili aday idareciyi getiriyoruz
                     .Select(a => new AyinKopeginiGetirResponse
                        {
                            KopekAdi = a.Kopek.KopekAdi,
                            Cinsiyet = a.Kopek.Cinsiyet.ToString(),
                            GorevYeri = a.Kopek.Birim.KadroAdi,
                            Irki = a.Kopek.Irk.Name,
                            Idarecisi = a.Kopek.Idareci.Any()
                                ? a.Kopek.Idareci.FirstOrDefault().AdayIdareci.AdSoyad
                                : "Bilinmiyor"
                        }).ToListAsync();



                return Result<List<AyinKopeginiGetirResponse>>.Success(ayinKopegi);
            }
        }
    }

    public class GetDofOfTheMounthEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapGet("dashboard/GetDofOfTheMounth", async (ISender sender) =>
            {
                var request = new GetDofOfTheMounth.Query();
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
