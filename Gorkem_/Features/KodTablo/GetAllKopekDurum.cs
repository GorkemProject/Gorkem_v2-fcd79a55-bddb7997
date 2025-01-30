using AspNetCoreHero.Results;
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
    public static class GetAllKopekDurum
    {
        public class Query : IRequest<Result<List<KopekDurumGetirResponse>>>
        {

        }
        public class BirimGetirValidation : AbstractValidator<Query>
        {
            public BirimGetirValidation()
            {
                //Listeleme işlemi yaptığımız için herhangi bir validasyon yapmadım. 
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KopekDurumGetirResponse>>>
        {


            public async Task<Result<List<KopekDurumGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifKopekDurumlari = await Context.KT_KopekDurumus
                    .Where(b => b.Aktifmi)
                    .Select(b => new KopekDurumGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return Result<List<KopekDurumGetirResponse>>.Success(aktifKopekDurumlari);
            }
        }
    }
    public class GetAllKopekDurumEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapGet("kodtablo/kopekdurum", async (ISender sender) =>
             {
                 var request = new GetAllKopekDurum.Query();
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
