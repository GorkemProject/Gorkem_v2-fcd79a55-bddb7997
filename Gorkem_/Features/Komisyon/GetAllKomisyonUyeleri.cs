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
    public static class GetAllKomisyonUyeleri
    {
        public class Query : IRequest<Result<List<KomisyonUyeleriGetirResponse>>>
        {

        }
        public class KomisyonUyeGetirValidation : AbstractValidator<Query>
        {
            public KomisyonUyeGetirValidation()
            {
                //Listeleme işlemi yaptığım için herhangi bir validasyon yapmadım..
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KomisyonUyeleriGetirResponse>>>
        {
            public async Task<Result<List<KomisyonUyeleriGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifUyeler = await Context.UT_KomisyonUyeleris
                    .Where(a => a.Aktifmi)
                    .Select(a => new KomisyonUyeleriGetirResponse
                    {
                        Id = a.Id,
                        TcKimlikNo=a.TcKimlikNo,
                        AdSoyad=a.AdSoyad,
                        Sicil=a.Sicil,
                        GorevUnvani=a.GorevUnvani,
                        GorevYeri=a.GorevYeri,
                        Eposta=a.Eposta,
                        CepTelefonu=a.CepTelefonu
                    }).ToListAsync(cancellationToken);
                return Result<List<KomisyonUyeleriGetirResponse>>.Success(aktifUyeler);
            }
        }
    }

    public class GetAllKomisyonUyeleriEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("komisyonUyeleri/getAllKomisyonUyeleri", async (ISender sender) =>
            {
                var request = new GetAllKomisyonUyeleri.Query();
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
