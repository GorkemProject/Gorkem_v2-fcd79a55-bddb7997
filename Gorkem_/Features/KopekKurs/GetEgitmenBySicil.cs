using System.Xml.Serialization;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetEgitmenBySicil
    {
        public class Query : IRequest<Result<List<SicileGoreEgitmenGetirResponse>>>
        {
            public int Sicil { get; set; }
            public Query(int sicil)
            {
                Sicil = sicil;
            }
        }

        internal sealed class Handler : IRequestHandler<Query, Result<List<SicileGoreEgitmenGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<SicileGoreEgitmenGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var egitmenler = await _context.UT_KursEgitmenler
                    .Where(e => e.Sicil == request.Sicil && e.Aktifmi)
                    .Select(e => new SicileGoreEgitmenGetirResponse
                    {
                        AdiSoyadi = e.AdSoyad,
                        Sicil = e.Sicil,
                        KadroIl = e.Birim.Adi//
                    }).ToListAsync();

                if (egitmenler == null)
                {
                    return Result<List<SicileGoreEgitmenGetirResponse>>.Fail("Sicile göre eğtimen getirilemedi");
                }
                return Result<List<SicileGoreEgitmenGetirResponse>>.Success(egitmenler);
            }
        }
    }
    public class GetEgitmenBySicilEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kopekKurs/GetEgitmenBySicil", async (int sicil, ISender sender) =>
            {
                var request = new GetEgitmenBySicil.Query(sicil);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
