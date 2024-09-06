using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllIdareciDurum
    {
        public class Query : IRequest<List<IdareciDurumGetirResponse>>
        {
        }
        public class DurumGetirValidation : AbstractValidator<Query>
        {
            public DurumGetirValidation()
            {
                //Listeleme işlemi yapılacağı için bir validasyon koymadım.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, List<IdareciDurumGetirResponse>>
        {
 

            public async Task<List<IdareciDurumGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifDurumlar = await Context.KT_IdareciDurum
                    .Where(b => b.Aktifmi)
                    .Select(b => new IdareciDurumGetirResponse
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
            app.MapGet("kodtablo/idarecidurum", async (ISender sender) =>
            {
                var request = new GetAllIdareciDurum.Query();
                var response = await sender.Send(request);
                return Results.Ok(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
