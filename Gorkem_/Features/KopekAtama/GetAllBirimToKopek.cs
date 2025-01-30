using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekAtama;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekAtama
{
    public static class GetAllBirimToKopek
    {
        public record Query(int KopekId): IRequest<Result<List<KopekCalKadGetirResponse>>>;

        internal sealed class Handler : IRequestHandler<Query, Result<List<KopekCalKadGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KopekCalKadGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var kopekCalismaDetay = await _context.UT_KopekCalKads
                    .Where(k => k.KopekId == request.KopekId)
                    .Include(k => k.AdayIdareci)
                    .Include(k => k.Birim)
                    .Select(k => new KopekCalKadGetirResponse
                    {
                        KopekId = k.KopekId,
                        IdareciId = k.AdayIdareciId,
                        IdareciAdi = k.AdayIdareci.AdSoyad,
                        BirimAdi = k.Birim.Adi, // Birim adını ekliyoruz
                        GoreveBaslamaTarihi = k.T_GoreveBaslama,
                        EvrakAtamaTarihi = k.T_EvrakAtama,
                        IlisikKesmeTarihi = k.T_IlisikKesme,
                        AtamaTuru = k.AtamaTuru,
                        AtamaEvrakSayisi = k.AtamaEvrakSayısı

                    }).ToListAsync(cancellationToken);

                if (kopekCalismaDetay == null)
                    return await Result<List<KopekCalKadGetirResponse>>.FailAsync("Belirtilen köpeğe ait çalışma detayları bulunamadı.");
                return await Result<List<KopekCalKadGetirResponse>>.SuccessAsync(kopekCalismaDetay);
                


            }
        }
    }

    public class GetAllBirimToKopekEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           var mapGet= app.MapGet("kopekAtama/getAllBirimToKopek", async (int kopekId, ISender sender) =>
            {
                var request = new GetAllBirimToKopek.Query(kopekId);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOPEKATAMA);
            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
