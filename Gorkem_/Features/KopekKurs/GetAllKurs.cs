using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetAllKurs
    {

        public class Query : IRequest<Result<List<KurslariGetirResponse>>>
        {

        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KurslariGetirResponse>>>

        {
            public async Task<Result<List<KurslariGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifKurslar = await Context.UT_Kurs
                    .Where(a => a.Aktifmi)
                    .Include(a => a.KursYeri)
                    .Include(a => a.KursEgitimListesi)
                    .Select(a => new KurslariGetirResponse
                    {
                        Donem = a.Donem,
                        KursEgitimListesi = a.KursEgitimListesi.Name,
                        KursEgitimListesiId = a.KursEgitimListesiId,
                        KursYeri = a.KursYeri.Name,
                        KursYeriId = a.KursYeriId,
                        T_KursBaslangic = a.T_KursBaslangic,
                        T_KursBitis = a.T_KursBitis
                    }).ToListAsync(cancellationToken);

                return Result<List<KurslariGetirResponse>>.Success(aktifKurslar);

            }
        }
    }

    public class GetAllKursEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kopekKurs/GetAllKurs", async (ISender sender) =>
            {
                var request = new GetAllKurs.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
