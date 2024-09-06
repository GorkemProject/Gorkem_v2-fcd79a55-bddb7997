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
        public class Query : IRequest<List<IrkGetirResponse>> { }

        public class IrkGetirValidation : AbstractValidator<Query>
        {
            public IrkGetirValidation()
            {
                //Listeleme işlemi yapıldığı için herhangi bir validasyon işlemi yapmadım.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, List<IrkGetirResponse>>
        {
 

            public async Task<List<IrkGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifIrklar = await Context.KT_Irks
                    .Where(b => b.Aktifmi)
                    .Select(b => new IrkGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return aktifIrklar;
            }
        }
    }
    public class GetAllIrkEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/irk", async (ISender sender) =>
            {
                var request = new GetAllIrk.Query();
                var response = await sender.Send(request);
                return Results.Ok(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
