using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekAtama;
using Gorkem_.EndpointTags;
using Gorkem_.Features.Kopek;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Gorkem_.Features.KopekAtama
{
    public static class GetAllKopekBirimleri
    {

        public record Query() : IRequest<Result<List<KopekBirimGetirResponse>>>;


        public class Handler : IRequestHandler<Query, Result<List<KopekBirimGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KopekBirimGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var kopekler = await _context.UT_Kopek_Kopeks
                    .Include(k => k.Birim)
                    .ToListAsync(cancellationToken);

                if (kopekler == null)
                {
                    return await Result<List<KopekBirimGetirResponse>>.FailAsync("Hiçbir köpek bulunamadı");
                }

                var response = kopekler.Select(k => new KopekBirimGetirResponse
                {
                    KopekId = k.Id,
                    KopekAdi = k.KopekAdi,
                    BirimAdi = k.Birim?.Adi
                }).ToList();

                return await Result<List<KopekBirimGetirResponse>>.SuccessAsync(response);
            }
        }

    }
    public class GetAllKopekBirimleriEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapGet("kopekAtama/getAllKopekBirimleri", async (ISender sender) =>
             {

                 var request = new GetAllKopekBirimleri.Query();
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
