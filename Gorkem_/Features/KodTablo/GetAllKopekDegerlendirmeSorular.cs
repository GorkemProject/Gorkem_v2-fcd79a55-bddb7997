using System.Formats.Asn1;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllKopekDegerlendirmeSorular
    {
        public class Query : IRequest<Result<List<KopekDegerlendirmeSorularGetirResponse>>>;

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KopekDegerlendirmeSorularGetirResponse>>>
        {
            public async Task<Result<List<KopekDegerlendirmeSorularGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var kopekSorular = await Context.KT_KursKopekDegerlendirmeSorular
                    .Where(a => a.Aktifmi)
                    .Select(a => new KopekDegerlendirmeSorularGetirResponse
                    {
                        Id = a.Id,
                        Name = a.Name
                    }).ToListAsync(cancellationToken);
                return Result<List<KopekDegerlendirmeSorularGetirResponse>>.Success(kopekSorular);
            }
        }
    }

    public class GetAllKopekDegerlendirmeSorularEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/GetAllKopekDegerlendimeSorular", async (ISender sender) =>
            {
                var request = new GetAllKopekDegerlendirmeSorular.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
