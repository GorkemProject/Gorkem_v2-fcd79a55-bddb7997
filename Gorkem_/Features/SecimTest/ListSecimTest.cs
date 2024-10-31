using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.SecimTest;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace Gorkem_.Features.SecimTest
{
    public static class ListSecimTest
    {
        public record Query(SecimTestiListeleRequest Request) : IRequest<Result<List<UT_SecimTest>>>;

        internal sealed class Handler : IRequestHandler<Query, Result<List<UT_SecimTest>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<UT_SecimTest>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.UT_SecimTests.AsQueryable();

                //Köpeğe göre filtreleme
                if (request.Request.KopekId.HasValue)
                {
                    query = query.Where(x => x.KopekId == request.Request.KopekId);
                }

                //KomisyonId Göre Filtreleme
                if (request.Request.KomisyonId.HasValue)
                {
                    query = query.Where(x => x.KomisyonId == request.Request.KomisyonId);
                }

                //Tarihe Göre Sıralama
                if (request.Request.BaslangicTarih.HasValue && request.Request.BitisTarihi.HasValue)
                {
                    query = query.Where(x => x.T_Aktif >= request.Request.BaslangicTarih && x.Tarih <= request.Request.BitisTarihi);
                }

                var secimTestleri = await query.ToListAsync(cancellationToken);
                return Result<List<UT_SecimTest>>.Success(secimTestleri);
            }
        }
    }

    public class ListSecimTestEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("secimTesti/ListSecimTesti", async ([FromBody] SecimTestiListeleRequest model, ISender sender) =>
            {
                var query = new ListSecimTest.Query(model);
                var response = await sender.Send(query);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.SECİMTEST);
        }
    }
}
