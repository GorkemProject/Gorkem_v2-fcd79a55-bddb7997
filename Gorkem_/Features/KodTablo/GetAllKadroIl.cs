using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllKadroIl
    {
        public class Query : IRequest<Result<List<KadroIlGetirResponse>>>
        {
        }

        public class KadroİlGetirValidation : AbstractValidator<Query>
        {
            public KadroİlGetirValidation()
            {
                //Listeleme işlemi yaptığımız için herhangi bir validasyon yapmadım. 
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KadroIlGetirResponse>>>
        {
 

            public async Task<Result<List<KadroIlGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifBirimler = await Context.KT_KadroIls
                    .Where(b => b.Aktifmi)
                    .Select(b => new KadroIlGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return Result<List<KadroIlGetirResponse>>.Success(aktifBirimler);
            }
        }
    }
    public class GetAllBirimEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/kadroil", async (ISender sender) =>
            {
                var request = new GetAllKadroIl.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KODTABLO);
        }
    }


}
