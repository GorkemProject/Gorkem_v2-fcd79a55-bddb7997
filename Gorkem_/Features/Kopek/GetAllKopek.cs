using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Kopek;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Kopek
{
    public static class GetAllKopek
    {
        public class Query : IRequest<List<KopekGetirResponse>>
        {

        }
        public class KopekGetirValidation : AbstractValidator<Query>
        {
            public KopekGetirValidation()
            {
                //listeleme işlemi yaptığımız için herhangi bir validasiyon işlemi olmayacak.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, List<KopekGetirResponse>>
        {
 

            public async Task<List<KopekGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifKopekler = await Context.UT_Kopek_Kopeks
                    .Where(a => a.Aktifmi)
                    .Select(a => new KopekGetirResponse
                    {
                        Id = a.Id,
                        IrkId = a.IrkId,
                        BirimId = a.BirimId,
                        BransId = a.BransId,
                        KopekTuruId = a.KopekTuruId,
                        DurumId = a.DurumId,
                        KuvveNumarasi = a.KuvveNumarasi,
                        CipNumarasi = a.CipNumarasi,
                        Karar = a.Karar,
                        DogumTarihi = a.DogumTarihi,
                        YapilanIslem = a.YapilanIslem,
                        NihaiKanaat = a.NihaiKanaat,
                        TeminSekli = a.TeminSekli,
                        T_Aktif = a.T_Aktif,
                        T_Pasif = a.T_Pasif
                    }).ToListAsync(cancellationToken);
                return aktifKopekler;
            }
        }
    }
    public class GetAllKopekEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kopek", async (ISender sender) =>
            {
                var request = new GetAllKopek.Query();
                var response = await sender.Send(request);
                return Results.Ok(response);
            }).WithTags(EndpointConstants.KOPEK);
        }
    }
}
