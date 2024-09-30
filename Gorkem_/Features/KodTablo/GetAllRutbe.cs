using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllRutbe
    {
        public class Query : IRequest<Result<List<RutbeGetirResponse>>>
        {
        }
        public class RutbeGetirValidation : AbstractValidator<Query>
        {
            public RutbeGetirValidation()
            {
                //listeleme işlemi yaptığım için validasyon yapmıyoruz.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<RutbeGetirResponse>>>
        {
 

            public async Task<Result<List<RutbeGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifRutbeler = await Context.KT_Rutbes
                    .Where(b => b.Aktifmi)
                    .Select(b => new RutbeGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return Result<List<RutbeGetirResponse>>.Success(aktifRutbeler);
            }
        }
    }
    public class GetAllRutbeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/rutbe", async (ISender sender) =>
            {
                var request = new GetAllRutbe.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
