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
    public static class GetAllKarar
    {
        public class Query : IRequest<Result<List<KararGetirResponse>>>
        {

        }
        public class KararGetirValidation : AbstractValidator<Query>
        {
            public KararGetirValidation()
            {
                //Listeleme işlemi yaptığım için validasyon yapmadım.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KararGetirResponse>>>
        {
            public async Task<Result<List<KararGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifKararlar = await Context.KT_Karars
                    .Where(b=>b.Aktifmi)
                    .Select(b=> new KararGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Neticesi=b.Neticesi
                    }).ToListAsync(cancellationToken);

                return Result<List<KararGetirResponse>>.Success(aktifKararlar);
            }
        }
    }

    public class GetAllKararEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/karar", async (ISender sender) =>
            {
                var request = new GetAllKarar.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
