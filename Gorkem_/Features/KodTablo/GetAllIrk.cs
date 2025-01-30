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
    public class GetAllIrk
    {
        public class Query : IRequest<Result<List<IrkGetirResponse>>> { }

        public class IrkGetirValidation : AbstractValidator<Query>
        {
            public IrkGetirValidation()
            {
                //Listeleme işlemi yapıldığı için herhangi bir validasyon işlemi yapmadım.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<IrkGetirResponse>>>
        {


            public async Task<Result<List<IrkGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifIrklar = await Context.KT_Irks
                    .Where(b => b.Aktifmi)
                    .Select(b => new IrkGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return Result<List<IrkGetirResponse>>.Success(aktifIrklar);
            }
        }
    }
    public class GetAllIrkEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapGet("kodtablo/irk", async (ISender sender) =>
             {
                 var request = new GetAllIrk.Query();
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
