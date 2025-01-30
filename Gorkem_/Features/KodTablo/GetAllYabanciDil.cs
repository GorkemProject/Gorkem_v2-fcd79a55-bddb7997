using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllYabanciDil
    {
        public class Query : IRequest<Result<List<YabanciDilGetirResponse>>>
        {

        }
        public class YabanciDilGetirValidation : AbstractValidator<Query>
        {
            public YabanciDilGetirValidation()
            {
                //Listeleme işlemi yaptığımız için herhangi bir validasyon yapmadım.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<YabanciDilGetirResponse>>>
        {
 

            public async Task<Result<List<YabanciDilGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifYabanciDiller = await Context.KT_YabanciDils
                    .Where(b=>b.Aktifmi)
                    .Select(b=> new YabanciDilGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return Result<List<YabanciDilGetirResponse>>.Success(aktifYabanciDiller);
            }
        }
    }
    public class GetAllYabanciDilEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           var mapGet= app.MapGet("kodtablo/yabancidil", async (ISender sender) =>
            {
                var request = new GetAllYabanciDil.Query();
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
