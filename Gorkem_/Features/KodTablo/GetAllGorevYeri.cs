using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllGorevYeri
    {
        public class Query : IRequest<Result<List<GorevYeriGetirResponse>>>
        {

        }


        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<GorevYeriGetirResponse>>>
        {
            public async Task<Result<List<GorevYeriGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifGorevYerleri = await Context.KT_GorevYeris
                    .Where(b=>b.Aktifmi)
                    .Select(b=> new GorevYeriGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,  
                    }).ToListAsync(cancellationToken);

                return Result<List<GorevYeriGetirResponse>>.Success(aktifGorevYerleri);
            }
        }
    }


    public class GetAllGorevYeriEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           var mapGet= app.MapGet("kodtablo/gorevYerleri", async (ISender sender) =>
            {
                var request = new GetAllGorevYeri.Query();
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
