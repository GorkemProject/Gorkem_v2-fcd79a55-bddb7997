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
        public class Query : IRequest<List<AskerlikGetirResponse>>
        {

        }
        public class AskerlikGetirValidation : AbstractValidator<Query>
        {
            public AskerlikGetirValidation()
            {
                //Listeleme işlemi yapıldığı için validasyona gerek yok.
            }    
        }
        internal sealed class Handler : IRequestHandler<Query, List<AskerlikGetirResponse>>
        {
            private readonly GorkemDbContext _context;
            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<List<AskerlikGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifAskerlikDurumları = await _context.KT_Askerliks
                    .Where(b => b.Aktifmi)
                    .Select(b => new AskerlikGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return aktifAskerlikDurumları;

            }
        }

    }
    public class GetAllAskerlikEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/askerlik", async (ISender sender) =>
            {
                var request = new GetAllAskerlik.Query();
                var response = await sender.Send(request);
                return Results.Ok(response);

            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
