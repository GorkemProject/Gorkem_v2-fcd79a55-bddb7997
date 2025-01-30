using AspNetCoreHero.Results;
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
        public class Query : IRequest<Result<List<BransGetirResponse>>> { }
        public class BransGetirValidation : AbstractValidator<Query>
        {
            public BransGetirValidation()
            {
                //Listeleme işlemi olduğu için herhangi bir validasyon yapmıyorum.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<BransGetirResponse>>>
        {
 
            public async Task<Result<List<BransGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifBranslar = await Context.KT_Branss
                    .Where(b => b.Aktifmi)
                    .Select(b => new BransGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return Result<List<BransGetirResponse>>.Success(aktifBranslar);
            }
        }
    }
    public class GetAllBransEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           var mapGet= app.MapGet("kodtablo/brans", async (ISender sender) =>
            {
                var request = new GetAllBrans.Query();
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
