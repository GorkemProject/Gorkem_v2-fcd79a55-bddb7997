using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Gorkem_.Features.Komisyon
{
    public static class GetKomisyonByUyeId
    { 
        public class Query : IRequest<Result<List<UyeninKomisyonlariniGetirResponse>>>
        {
            public int UyeId { get; set; }

            public Query(int uyeId)
            {
                UyeId = uyeId;
            }
        }

        internal sealed class Handler : IRequestHandler<Query, Result<List<UyeninKomisyonlariniGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<UyeninKomisyonlariniGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var komisyonlar = await _context.UT_KomisyonUyeleris
                    .Include(u => u.Komisyon)
                    .Where(u => u.Id == request.UyeId)
                    .SelectMany(u => u.Komisyon)
                    .Select(k => new UyeninKomisyonlariniGetirResponse
                    {
                        KomisyonAdi = k.KomisyonAdi,
                        GorevYeri = k.GorevYeri,
                        OlusturulmaTarihi = k.OlusturulmaTarihi

                    }).ToListAsync(cancellationToken);

                
                if (komisyonlar == null || !komisyonlar.Any())
                {
                    return Result<List<UyeninKomisyonlariniGetirResponse>>.Fail("Üyeye ait bir komisyon bulunamadı..");
                }

                return Result<List<UyeninKomisyonlariniGetirResponse>>.Success(komisyonlar);
            }
        }
    }

    public class GetKomisyonByUyeIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("uye/{uyeId}/komisyonlar", async ( int uyeId, ISender sender ) =>
            {
                var request = new GetKomisyonByUyeId.Query(uyeId);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
