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
        public class Query : IRequest<List<KopekDurumGetirResponse>>
        {

        }
        public class BirimGetirValidation : AbstractValidator<Query>
        {
            public BirimGetirValidation()
            {
                //Listeleme işlemi yaptığımız için herhangi bir validasyon yapmadım. 
            }
        }
        internal sealed class Handler : IRequestHandler<Query, List<KopekDurumGetirResponse>>
        {
            private readonly GorkemDbContext _context;
            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<List<KopekDurumGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifKopekDurumlari = await _context.KT_KopekDurumus
                    .Where(b=>b.Aktifmi)
                    .Select(b=> new KopekDurumGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return aktifKopekDurumlari;
            }
        }
    }
    public class GetAllKopekDurumEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/kopekdurum", async (ISender sender) =>
            {
                var request = new GetAllKopekDurum.Query();
                var response = await sender.Send(request);
                return Results.Ok(response);

            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
