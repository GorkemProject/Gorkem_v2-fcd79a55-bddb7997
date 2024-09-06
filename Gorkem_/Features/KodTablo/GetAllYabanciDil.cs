using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllYabanciDil
    {
        public class Query : IRequest<List<YabanciDilGetirResponse>>
        {

        }
        public class YabanciDilGetirValidation : AbstractValidator<Query>
        {
            public YabanciDilGetirValidation()
            {
                //Listeleme işlemi yaptığımız için herhangi bir validasyon yapmadım.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, List<YabanciDilGetirResponse>>
        {
 

            public async Task<List<YabanciDilGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifYabanciDiller = await Context.KT_YabanciDils
                    .Where(b=>b.Aktifmi)
                    .Select(b=> new YabanciDilGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return aktifYabanciDiller;
            }
        }
    }
    public class GetAllYabanciDilEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/yabancidil", async (ISender sender) =>
            {
                var request = new GetAllYabanciDil.Query();
                var response = await sender.Send(request);

                return Results.Ok(response);

            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
