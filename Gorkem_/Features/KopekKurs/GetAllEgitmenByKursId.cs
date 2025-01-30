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

        public class Query : IRequest<Result<List<KursEgitmenGetirResponse>>>
        {
            public int KursId { get; set; }
            public Query(int kursId)
            {
                KursId = kursId;
            }
        }

        internal sealed class Handler : IRequestHandler<Query, Result<List<KursEgitmenGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KursEgitmenGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var kursEgitmenler = await _context.UT_Kurs
                    .Where(k => k.Id == request.KursId && k.Aktifmi)
                    .SelectMany(k => k.KursEgitmenler
                    .Where(e => e.Aktifmi)
                    .Select(e => new KursEgitmenGetirResponse
                    {
                        Id = e.Id,
                        AdSoyad = e.AdSoyad,
                        BirimId = e.BirimId,
                        Birim = e.Birim.Adi,
                        RutbeId = e.RutbeId,
                        Rutbe = e.Rutbe.Name,
                        Sicil = e.Sicil

                    })).ToListAsync(cancellationToken);

                if (kursEgitmenler == null)
                {
                    return Result<List<KursEgitmenGetirResponse>>.Fail("Bu kursa ait eğitmen bulunamadı..");

                }
                return Result<List<KursEgitmenGetirResponse>>.Success(kursEgitmenler);
            }
        }
    }

    public class GetAllEgitmenByKursIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapGet("kopekKurs/GetKursEgitmenByKursId", async (int kursId, ISender sender) =>
             {
                 var request = new GetAllEgitmenByKursId.Query(kursId);

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
