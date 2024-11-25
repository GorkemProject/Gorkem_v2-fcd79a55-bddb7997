using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetAllEgitmenByKursId
    {

        public class Query : IRequest<Result<List<KursIdyeGoreKursEgitmenGetirResponse>>>
        {
            public int KursId { get; set; }
            public Query(int kursId)
            {
                KursId = kursId;
            }
        }

        internal sealed class Handler : IRequestHandler<Query, Result<List<KursIdyeGoreKursEgitmenGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KursIdyeGoreKursEgitmenGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var kursEgitmenler = await _context.UT_Kurs
                    .Where(k => k.Id == request.KursId && k.Aktifmi)
                    .SelectMany(k => k.KursEgitmenler
                    .Where(e => e.Aktifmi)
                    .Select(e => new KursIdyeGoreKursEgitmenGetirResponse
                    {
                        EgitmenId = e.Id,
                        EgitmenAdi = e.AdSoyad,
                        BirimAdi = e.Birim.KadroAdi,
                        RutbeAdi = e.Rutbe.Name

                    })).ToListAsync(cancellationToken);

                if (kursEgitmenler == null)
                {
                    return Result<List<KursIdyeGoreKursEgitmenGetirResponse>>.Fail("Bu kursa ait eğitmen bulunamadı..");

                }
                return Result<List<KursIdyeGoreKursEgitmenGetirResponse>>.Success(kursEgitmenler);
            }
        }
    }

    public class GetAllEgitmenByKursIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kopekKurs/GetKursEgitmenByKursId", async (int kursId, ISender sender) =>
            {
                var request = new GetAllEgitmenByKursId.Query(kursId);

                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
