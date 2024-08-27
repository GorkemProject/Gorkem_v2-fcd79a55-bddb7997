using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllKopekTuru
    {
        public class Query : IRequest<List<KopekTuruGetirResponse>>
        {
        }
        public class KopekTuruGetirValidation : AbstractValidator<Query>
        {
            public KopekTuruGetirValidation()
            {
                //Listeleme işlemi yaptığımız için herhangi bir validasyon yapmadım. 
            }
        }
        internal sealed class Handler : IRequestHandler<Query, List<KopekTuruGetirResponse>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<List<KopekTuruGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifKopekTurleri = await _context.KT_KopekTurus
                    .Where(b => b.Aktifmi)
                    .Select(b => new KopekTuruGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return aktifKopekTurleri;
            }
        }
    }
    public class GetAllKopekTuruEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/kopekturu", async (ISender sender) =>
            {
                var request = new GetAllKopekTuru.Query();
                var response = await sender.Send(request);

                return Results.Ok(response);

            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
