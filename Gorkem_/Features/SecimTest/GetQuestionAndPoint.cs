using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.SecimTest;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Gorkem_.Features.SecimTest
{
    public static class GetQuestionAndPoint
    {
        public class Query : IRequest<Result<List<SorularıVePuanlarınıGetirResponse>>>
        {
            public int CevapId { get; set; }

            public Query(int cevapId)
            {
                CevapId = cevapId;
            }
        }

        internal sealed class Handler : IRequestHandler<Query, Result<List<SorularıVePuanlarınıGetirResponse>>>
        {

            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<SorularıVePuanlarınıGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var questionAndPoint = await _context.UT_SecimTestiCevaplar
                    .Include(a=>a.Soru)
                    .Where(a=>a.Id==request.CevapId)
                    .Select(a=> new SorularıVePuanlarınıGetirResponse
                    {
                        Soru=a.Soru.Name,
                        KopekPuan=a.Puan,
                        SoruPuan=a.Soru.Puan
 

                    }).ToListAsync(cancellationToken);

                if (questionAndPoint == null)
                {
                    return Result<List<SorularıVePuanlarınıGetirResponse>>.Fail("Sorular ve puanları bulunamadı..");
                    
                }
                return Result<List<SorularıVePuanlarınıGetirResponse>>.Success(questionAndPoint);
            }
        }
    }

    public class GetQuestionAndPointEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("secimTesti/{cevapId}/GetQuestionAndPoint", async (int cevapId, ISender sender) =>
            {
                var request = new GetQuestionAndPoint.Query(cevapId);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.SECİMTEST);
        }
    }
}
