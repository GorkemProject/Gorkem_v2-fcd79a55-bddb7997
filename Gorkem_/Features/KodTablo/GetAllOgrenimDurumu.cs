using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllOgrenimDurumu
    {
        public class Query : IRequest<List<OgrenimDurumuGetirResponse>>
        {
        }
        public class OgrenimDurumuGetirValidation : AbstractValidator<Query>
        {
            public OgrenimDurumuGetirValidation()
            {
                //Listeleme işlemi yaptığımız için herhangi bir validasyon yapmadım. 
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, List<OgrenimDurumuGetirResponse>>
        {
 

            public async Task<List<OgrenimDurumuGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifOgrenimDurumlari = await Context.KT_OgrenimDurumus
                    .Where(b => b.Aktifmi)
                    .Select(b => new OgrenimDurumuGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return aktifOgrenimDurumlari;
            }
        }
    }
    public class GetAllOgrenimDurumuEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/ogrenimdurumu", async (ISender sender) =>
            {
                var request = new GetAllOgrenimDurumu.Query();
                var response = await sender.Send(request);

                return Results.Ok(response);

            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
