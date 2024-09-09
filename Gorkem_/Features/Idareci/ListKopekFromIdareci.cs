using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Idareci
{
    public static class ListKopekFromIdareci
    {
        public record Query (IdareciKopekListeleRequest Request) : IRequest<Result<List<IdareciKopekListeleResponse>>> { }

        internal sealed class Handler : IRequestHandler<Query, Result<List<IdareciKopekListeleResponse>>>
        {
            private readonly GorkemDbContext _context;
            public Handler(GorkemDbContext context)
            {
                _context = context;
            }


            public async Task<Result<List<IdareciKopekListeleResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.UT_IdareciKopekleri.AsQueryable();
                if (request.Request.Aktifmi.HasValue)
                {
                    query = query.Where(x => x.Aktifmi == request.Request.Aktifmi.Value);
                }
                var result = await query.Select(x=> new IdareciKopekListeleResponse
                {
                    KopekId = x.KopekId,
                    IdareciId = x.IdareciId,
                    Aktifmi = x.Aktifmi,
                    
                }).ToListAsync(cancellationToken);
                return await Result<List<IdareciKopekListeleResponse>>.SuccessAsync(result);
            }
        }
    }
    public class ListKopekFromIdareciEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("idarecikopek", async ([FromQuery] bool? aktifmi, ISender sender) =>
            {
                var request = new IdareciKopekListeleRequest { Aktifmi = aktifmi };
                var response = await sender.Send(new ListKopekFromIdareci.Query(request));
                if (response.Succeeded)
                    return Results.Ok(response.Data);


                return Results.BadRequest(response.Message);
            }).WithTags(EndpointConstants.IDARECI);
        }
    }
}
