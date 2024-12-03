using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetKursByKursId
    {
        public class Query : IRequest<Result<IdNumarasinaGoreKursGetirResponse>>
        {
            public int KursId { get; set; }

            public Query(int kursId)
            {
                KursId = kursId;
            }
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger)
            : IRequestHandler<Query, Result<IdNumarasinaGoreKursGetirResponse>>
        {
            public async Task<Result<IdNumarasinaGoreKursGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                

                var kurs = await Context.UT_Kurs
                    .Include(a => a.KursEgitimListesi)
                    .Include(a => a.KursYeri)
                    .FirstOrDefaultAsync(x => x.Id == request.KursId && x.Aktifmi);

                if (kurs == null)
                {
                    
                    return Result<IdNumarasinaGoreKursGetirResponse>.Fail($"Kurs bulunamadı: {request.KursId}");
                }

                var kursResponse = new IdNumarasinaGoreKursGetirResponse
                {
                    KursId = kurs.Id,
                    BaslangicTarih = kurs.T_KursBaslangic ?? DateTime.MinValue,
                    BitisTarih = kurs.T_KursBitis ?? DateTime.MinValue,
                    Donemi = kurs.Donem,
                    KursAdi = kurs.KursEgitimListesi?.Name ?? "Bilinmiyor",
                    KursYeri = kurs.KursYeri?.Name ?? "Bilinmiyor"
                };

                return Result<IdNumarasinaGoreKursGetirResponse>.Success(kursResponse);
            }
        }
    }

    public class GetKursByKursIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kopekKurs/GetKursByKursId/{kursId:int}", async (int kursId, ISender sender) =>
            {
                var request = new GetKursByKursId.Query(kursId);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
