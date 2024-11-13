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
    public static class GetAllKursMufredat
    {
        public class Query : IRequest<Result<List<KursMufredatGetirResponse>>>
        {

        }

        public class KursMufredatGetirValidation : AbstractValidator<Query>
        {
            public KursMufredatGetirValidation()
            {
                //Listeleme işlemi yapıldığı için validasyona gerek yok.
            }
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KursMufredatGetirResponse>>>
        {
            public async Task<Result<List<KursMufredatGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifMufredatlar = await Context.KT_KursMufredats
                    .Include(k => k.KursEgitimListesi)
                    .Where(b => b.Aktifmi)
                    .Select(b => new KursMufredatGetirResponse
                    {
                        Id = b.Id,
                        KursName = b.KursEgitimListesi.Name,
                        KursId = b.KursEgitimListesiId,
                        Name = b.Name
                    }).ToListAsync(cancellationToken);

                return Result<List<KursMufredatGetirResponse>>.Success(aktifMufredatlar);
            }
        }
    }

    public class GetAllKursMufredatEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/GetAllKursMufredat", async (ISender sender) =>
            {
                var request = new GetAllKursMufredat.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
