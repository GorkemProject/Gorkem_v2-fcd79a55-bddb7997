using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Collections.Immutable;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllBrans
    {
        public class Query : IRequest<List<BransGetirResponse>> { }
        public class BransGetirValidation : AbstractValidator<Query>
        {
            public BransGetirValidation()
            {
                //Listeleme işlemi olduğu için herhangi bir validasyon yapmıyorum.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, List<BransGetirResponse>>
        {
 
            public async Task<List<BransGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifBranslar = await Context.KT_Branss
                    .Where(b => b.Aktifmi)
                    .Select(b => new BransGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return aktifBranslar;
            }
        }
    }
    public class GetAllBransEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/brans", async (ISender sender) =>
            {
                var request = new GetAllBrans.Query();
                var response = await sender.Send(request);
                return Results.Ok(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
