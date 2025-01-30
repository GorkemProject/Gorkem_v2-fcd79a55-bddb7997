using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.SecimTest;
using Gorkem_.EndpointTags;
using Gorkem_.Enums;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.SecimTest
{
    public static class GetQuestionsByTestId
    {
        public class Query : IRequest<Result<List<TestinSorulariniGetirResponse>>>
        {
            public int TestId { get; set; }

            public Query(int testId)
            {
                TestId = testId;
            }
        }
        internal sealed class Handler : IRequestHandler<Query, Result<List<TestinSorulariniGetirResponse>>>
        {

            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<TestinSorulariniGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var sorular = await _context.KT_Sorus
                    .Include(u => u.SecimTest)
                    .Where(u => u.SecimTestId == request.TestId)
                    .Select(k => new TestinSorulariniGetirResponse
                    {
                        Id = k.Id,
                        Name = k.Name,
                        Puan = k.Puan
                    }).ToListAsync(cancellationToken);

                if (sorular == null || !sorular.Any())
                {
                    return Result<List<TestinSorulariniGetirResponse>>.Fail("Teste ait bir soru bulunamadı");
                }
                return Result<List<TestinSorulariniGetirResponse>>.Success(sorular);
            }
        }

    }

    public class GetQuestionsByTestIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapGet("secimTesti/{testId}/getTestSorular", async (int testId, ISender sender) =>
              {
                  var request = new GetQuestionsByTestId.Query(testId);
                  var response = await sender.Send(request);


                  if (response.Succeeded)
                      return Results.Ok(response);
                  return Results.BadRequest(response);
              }).WithTags(EndpointConstants.SECİMTEST);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
