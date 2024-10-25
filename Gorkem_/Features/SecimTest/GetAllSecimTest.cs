using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.SecimTest;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.SecimTest
{
    public static class GetAllSecimTest
    {
        public class Query : IRequest<Result<List<SecimTestiGetirResponse>>>
        {

        }


        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<SecimTestiGetirResponse>>>
        {
            public async Task<Result<List<SecimTestiGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var testList = await Context.KT_SecimTests
                    .Select(a => new SecimTestiGetirResponse
                    {
                        Id = a.Id,
                        Name = a.Name,
                    }).ToListAsync(cancellationToken);
                return Result<List<SecimTestiGetirResponse>>.Success(testList);
            }
        }
    }
    public class GetAllSecimTestEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("secimTesti/getAllSecimTest", async (ISender sender) =>
            {
                var request =new GetAllSecimTest.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.SECİMTEST);
        }
    }
}
