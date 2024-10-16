using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Komisyon
{
    public static class GetAllKomisyon
    {
        public class Query : IRequest<Result<List<KomisyonGetirResponse>>>
        {

        }
        public class KomisyonGetirValidation : AbstractValidator<Query>
        {
            public KomisyonGetirValidation()
            {
                //Listeleme işlemi yapıldığı için herhangi bir validasyon yok..
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KomisyonGetirResponse>>>
        {
            public async Task<Result<List<KomisyonGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var komisyonList = await Context.UT_Komisyons
                    .Where(a=>a.Aktifmi)
                    .Select(a=> new KomisyonGetirResponse
                    {
                        Id=a.Id,
                        GorevYeri = a.GorevYeri,
                        KomisyonAdi = a.KomisyonAdi,
                        OlusturulmaTarihi=a.OlusturulmaTarihi,
                    
                    }).ToListAsync(cancellationToken);
                return Result<List<KomisyonGetirResponse>>.Success(komisyonList);
            }
        }
    }
    public class GetAllKomisyonEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("komisyon", async (ISender sender) =>
            {
                var request = new GetAllKomisyon.Query();
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response.Message);
            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
