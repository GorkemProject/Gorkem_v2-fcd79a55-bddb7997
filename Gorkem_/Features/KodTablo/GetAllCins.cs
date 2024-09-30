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
    public static class GetAllCins
    {
        public class Query : IRequest<Result<List<CinsGetirResponse>>>
        {
        }
        public class BirimGetirValidation : AbstractValidator<Query>
        {
            public BirimGetirValidation()
            {
                //Listeleme işlemi yaptığımız için herhangi bir validasyon yapmadım. 
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<CinsGetirResponse>>>
        {
 
            public async Task<Result<List<CinsGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifCinsler = await Context.KT_Cinss
                    .Where(b => b.Aktifmi)
                    .Select(b => new CinsGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return Result<List<CinsGetirResponse>>.Success(aktifCinsler);

                    
            }
        }
    }
    public class GetAllCinsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/cins", async (ISender sender) =>
            {
                var request = new GetAllCins.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }

}
