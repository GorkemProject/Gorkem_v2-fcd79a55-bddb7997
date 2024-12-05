using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetAllKursiyer
    {
        public class Query : IRequest<Result<List<KursiyerGetirResponse>>>
        {

        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KursiyerGetirResponse>>>
        {
            public async Task<Result<List<KursiyerGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifKursiyerler = await Context.UT_Kursiyer
                    .Where(a => a.Aktifmi)
                    //.Include(a => a.Idareci)
                    //.ThenInclude(i => i.Kopek)
                    //.ThenInclude(a => a.Kopek)
                    .Select(kursiyer => new KursiyerGetirResponse
                    {
                        ////KursiyerId = kursiyer.IdareciId,
                        ////KursiyerAdi = kursiyer.Idareci.AdSoyad,
                        ////Kopekler = kursiyer.Idareci.Kopek
                        //.Select(Kopek => new KursiyerKopekleriResponse
                        //{
                        //    KopekAdi = Kopek.Kopek.KopekAdi,
                        //    KopekId = Kopek.Kopek.Id

                        //}).ToList()

                    }).ToListAsync(cancellationToken);


                return Result<List<KursiyerGetirResponse>>.Success(aktifKursiyerler);
            }
        }
    }
    public class GetAllKursiyerEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kopekKurs/GetAllKursiyerAndKopek", async (ISender sender) =>
            {
                var request =new GetAllKursiyer.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }

}
