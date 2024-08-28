using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.UygulamaTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.UygulamaTablo
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
        internal sealed class Handler : IRequestHandler<Query, List<KopekGetirResponse>>
        {
            private readonly GorkemDbContext _context;
            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<List<KopekGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifKopekler = await _context.UT_Kopek_Kopeks
                    .Where(a => a.Aktifmi)
                    .Select(a => new KopekGetirResponse
                    {
                        Id = a.Id,
                        Name = a.Name,
                        IrkRef = a.IrkRef,
                        BirimRef = a.BirimRef,
                        BransRef = a.BransRef,
                        KopekTuruRef = a.KopekTuruRef,
                        DurumRef = a.DurumRef,
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
            app.MapGet("uygulamatablo/kopek", async (ISender sender) =>
            {
                var request = new GetAllKopek.Query();
                var response = await sender.Send(request);
                return Results.Ok(response);
            }).WithTags(EndpointConstants.UYGULAMATABLO);
        }
    }
}
