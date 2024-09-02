using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllDurum
    {
        public class Query : IRequest<List<DurumGetirResponse>>
        {
        }
        public class DurumGetirValidation : AbstractValidator<Query>
        {
            public DurumGetirValidation()
            {
                //Listeleme işlemi yapılacağı için bir validasyon koymadım.
            }
        }
        internal sealed class Handler : IRequestHandler<Query, List<DurumGetirResponse>>
        {
            public readonly GorkemDbContext _context;
            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<List<DurumGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifDurumlar = await _context.KT_Durums
                    .Where(b => b.Aktifmi)
                    .Select(b => new DurumGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return aktifDurumlar;
            }
        }
    }
    public class GetAllDurumEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/durum", async (ISender sender) =>
            {
                var request = new GetAllDurum.Query();
                var response = await sender.Send(request);
                return Results.Ok(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
