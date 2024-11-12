using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Kopek;
using Gorkem_.EndpointTags;
using Gorkem_.Enums;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Kopek
{
    public static class GetAllKopek
    {
        public class Query : IRequest<Result<List<KopekGetirResponse>>>
        {

        }
        public class KopekGetirValidation : AbstractValidator<Query>
        {
            public KopekGetirValidation()
            {
                //listeleme işlemi yaptığımız için herhangi bir validasiyon işlemi olmayacak.
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KopekGetirResponse>>>
        {
 

            public async Task<Result<List<KopekGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                TypeAdapterConfig<UT_Kopek, KopekGetirResponse>
                    .NewConfig()
                    .Map(dest => dest.IrkId, src => src.Irk.Name);
                var aktifKopekler = await Context.UT_Kopek_Kopeks
                    .Where(a => a.Aktifmi && a.KopekDurum != Enum_KopekDurum.SaglikRed)
                    .Select(a => new KopekGetirResponse
                    {

                        Id = a.Id,
                        KopekAdi = a.KopekAdi,
       
                        IrkId = a.IrkId,
                        KadroIlId = a.KadroIlId,
                        BransId = a.BransId,
                        KuvveNumarasi = a.KuvveNumarasi,
                        CipNumarasi = a.CipNumarasi,
                        KararId = a.KararId,
                        DogumTarihi = a.DogumTarihi,
                        YapilanIslem = a.YapilanIslem,
                        NihaiKanaat = a.NihaiKanaat,
                        EdinimSekli=a.EdinimSekli,
                        T_Aktif = a.T_Aktif,
                        T_Pasif = a.T_Pasif,
                        Cinsiyet = a.Cinsiyet,
                        AnneKopekId = a.AnneKopekId,
                        BabaKopekId= a.BabaKopekId,
                        EdinilenKisi = a.EdinilenKisi,
                        EdinilmeTarihi=a.EdinilmeTarihi,
                        EdinilenKisiTelefon=a.EdinilenKisiTelefon,
                        EdinilenKisiAdres=a.EdinilenKisiAdres,

                        
                    }).ToListAsync(cancellationToken);
                return Result<List<KopekGetirResponse>>.Success(aktifKopekler);
            }
        }
    }
    public class GetAllKopekEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kopek/getAllKopek", async (ISender sender) =>
            {
                var request = new GetAllKopek.Query();
                var response = await sender.Send(request);
                return Results.Ok(response);
            }).WithTags(EndpointConstants.KOPEK);
        }
    }
}
