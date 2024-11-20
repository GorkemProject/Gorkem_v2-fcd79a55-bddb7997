using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetAllKGRMufredat
    {

        public class Query : IRequest<Result<List<KGRMufredatGetirResponse>>>
        {
            
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KGRMufredatGetirResponse>>>
        {
            public async Task<Result<List<KGRMufredatGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifKGRMufredatlar = await Context.UT_KGRMufredats
                    .Where(a => a.Aktifmi)
                    .Include(a => a.Mufredat)
                    .Select(a => new KGRMufredatGetirResponse
                    {
                        Id=a.Id,
                        Mufredat=a.Mufredat.Name,
                        MufredatId=a.MufredatId
                    }).ToListAsync(cancellationToken);

                return Result<List<KGRMufredatGetirResponse>>.Success(aktifKGRMufredatlar);


            }
        }
    }

    public class GetAllKGRMufredatEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kopekKurs/GetAllKGRMufredats", async (ISender sender) =>
            {
                var request = new GetAllKGRMufredat.Query();
                var response = await sender.Send(request);


                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
