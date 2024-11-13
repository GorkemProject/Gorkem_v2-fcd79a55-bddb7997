using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllKursEgitimListesi
    {
        public class Query : IRequest<Result<List<KursEgitimListesiGetirResponse>>>
        {

        }
        public class KursEgitimListesiGetirValidation : AbstractValidator<Query>
        {
            public KursEgitimListesiGetirValidation()
            {
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KursEgitimListesiGetirResponse>>>
        {
            public async Task<Result<List<KursEgitimListesiGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifKurslar = await Context.KT_KursEgitimListesis
                    .Where(k => k.Aktifmi)
                    .Select(b => new KursEgitimListesiGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name
                    }).ToListAsync(cancellationToken);

                return Result<List<KursEgitimListesiGetirResponse>>.Success(aktifKurslar);
            }
        }
    }

    public class GetAllKursEgitimListesiEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/GetAllKursEgitimListesi", async (ISender sender) =>
            {
                var request = new GetAllKursEgitimListesi.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
