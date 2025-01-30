using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllAskerlik
    {
        public class Query : IRequest<Result<List<AskerlikGetirResponse>>>
        {

        }
        public class AskerlikGetirValidation : AbstractValidator<Query>
        {
            public AskerlikGetirValidation()
            {
                //Listeleme işlemi yapıldığı için validasyona gerek yok.
            }    
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<AskerlikGetirResponse>>>
        {
 

            public async Task<Result<List<AskerlikGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifAskerlikDurumları = await Context.KT_Askerliks
                    .Where(b => b.Aktifmi)
                    .Select(b => new AskerlikGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);


                return Result<List<AskerlikGetirResponse>>.Success(aktifAskerlikDurumları);

            }
        }

    }
    public class GetAllAskerlikEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           var mapGet= app.MapGet("kodtablo/askerlik", async (ISender sender) =>
            {
                var request = new GetAllAskerlik.Query();
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


