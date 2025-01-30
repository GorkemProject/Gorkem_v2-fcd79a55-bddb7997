using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllIdareciDurum
    {
        public class Query : IRequest<Result<List<IdareciDurumGetirResponse>>>
        {
        }
        public class DurumGetirValidation : AbstractValidator<Query>
        {
            public DurumGetirValidation()
            {
                //Listeleme işlemi yapılacağı için bir validasyon koymadım.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<IdareciDurumGetirResponse>>>
        {
 

            public async Task<Result<List<IdareciDurumGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifDurumlar = await Context.KT_IdareciDurum
                    .Where(b => b.Aktifmi)
                    .Select(b => new IdareciDurumGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return Result<List<IdareciDurumGetirResponse>>.Success(aktifDurumlar);
            }
        }
    }
    public class GetAllDurumEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           var mapGet= app.MapGet("kodtablo/idarecidurum", async (ISender sender) =>
            {
                var request = new GetAllIdareciDurum.Query();
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
