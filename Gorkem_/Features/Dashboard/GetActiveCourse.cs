using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Dashboard;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Dashboard
{
    public static class GetActiveCourse
    {
        public class Query : IRequest<Result<List<AktifKurslariGetirResponse>>> { }

        public class Handler(GorkemDbContext Context) : IRequestHandler<Query, Result<List<AktifKurslariGetirResponse>>>
        {
            public async Task<Result<List<AktifKurslariGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var today = DateTime.Now;


                var aktifKurslar = Context.UT_Kurs
                    .Where(k => k.T_KursBaslangic <= today && k.T_KursBitis >= today)
                    .Include(a => a.KursYeri)
                    .Include(a => a.KursEgitimListesi)
                    .Include(a => a.Kursiyerler)
                    .Select(c => new AktifKurslariGetirResponse
                    {
                        KursAdi = c.KursEgitimListesi.Name,
                        Donemi = c.Donem,
                        KursYeri = c.KursYeri.Name,
                        KursiyerSayisi = c.Kursiyerler.Count()
                    }).ToListAsync(cancellationToken);

                return Result<List<AktifKurslariGetirResponse>>.Success(await aktifKurslar);
            }
        }
    }

    public class GetActiveCourseEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            var mapGet = app.MapGet("dashboard/GetActiveCourse", async (ISender sender) =>
            {
                var request = new GetActiveCourse.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.DASHBOARD);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }


            //if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            //{
            //    app.MapGet("dashboard/GetActiveCourse", async (ISender sender) =>
            //    {
            //        var request = new GetActiveCourse.Query();
            //        var response = await sender.Send(request);

            //        if (response.Succeeded)
            //            return Results.Ok(response);
            //        return Results.BadRequest(response);
            //    }).WithTags(EndpointConstants.DASHBOARD).RequireAuthorization();
            //}
            //else
            //{
            //    app.MapGet("dashboard/GetActiveCourse", async (ISender sender) =>
            //    {
            //        var request = new GetActiveCourse.Query();
            //        var response = await sender.Send(request);

            //        if (response.Succeeded)
            //            return Results.Ok(response);
            //        return Results.BadRequest(response);
            //    }).WithTags(EndpointConstants.DASHBOARD);
            //}

        }
    }
}
