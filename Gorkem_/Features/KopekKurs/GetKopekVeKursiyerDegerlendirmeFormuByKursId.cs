using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetKopekVeKursiyerDegerlendirmeFormuByKursId
    {

        public class Query : IRequest<Result<List<KopekVeKursiyerDegerlendirmeFormuGetirResponse>>>
        {
            public int KursId { get; set; }

            public Query(int kursId)
            {
                KursId = kursId;
            }
        }

        internal sealed class Handler : IRequestHandler <Query, Result<List<KopekVeKursiyerDegerlendirmeFormuGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KopekVeKursiyerDegerlendirmeFormuGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var kopekVeIdareciDegerlendirme = await _context.UT_KopekVeIdareciDegerlendirmeFormu
                    .Where(a => a.Aktifmi && a.KursId==request.KursId)

                    .Include(a => a.Kurs)
                        .ThenInclude(a => a.KursEgitimListesi)
                    .Include(a => a.Kurs.KursEgitmenler)
                    .Include(a => a.Kurs.Kursiyerler)
                    //    .ThenInclude(a=>a.Idareci)
                    //    .ThenInclude(a=>a.Kopek)
                    //.Include(a => a.Kurs)
                    //    .ThenInclude(a => a.Kursiyerler)                        
                    //    .ThenInclude(a => a.Idareci)
                        //.ThenInclude(a=>a.Kopek)
                    .Include(a => a.KopekDegerlendirmeCevaplar)
                    .Include(a => a.KursiyerDegerlendirmeCevaplar)
                    .Select(k => new KopekVeKursiyerDegerlendirmeFormuGetirResponse
                    {
                        TarihSaat=k.TarihSaat,
                        TestinYapildigiYer=k.TestinYapildigiYer,
                        TestinYapildigiIl=k.TestinYapildigiIl.Name,
                        KursAdı=k.Kurs.KursEgitimListesi.Name,
                        //KopekDegerlendirmeBilgiler = k.Kurs.Kursiyerler.Select(a=> new KopekDegerlendirmeFormuBilgilerResponse
                        //{
                        //    Adi=a.Idareci.Kopek.FirstOrDefault().Kopek.KopekAdi,
                        //    Bransi = a.Idareci.Kopek.FirstOrDefault().Kopek.Brans.Name,
                        //    //Cinsiyet = a.Idareci.Kopek.FirstOrDefault().Kopek.Cinsiyet,
                        //    CipNo=a.Idareci.Kopek.FirstOrDefault().Kopek.CipNumarasi,
                        //    DogumTarihi=a.Idareci.Kopek.FirstOrDefault().Kopek.DogumTarihi

                        //}).ToList(),
                        //KursiyerDegerlendirmeBilgiler = k.Kurs.Kursiyerler.Select(a=> new KursiyerDegerlendirmeFormuBilgilerResponse
                        //{
                        //    AdiSoyadi=a.Idareci.AdSoyad,
                        //    Kadrosu=a.Idareci.KadroIl.Name,
                        //    Sicili=a.Idareci.Sicil
                        //}).ToList(),
                        KopekDegerlendirmeCevaplar=k.KopekDegerlendirmeCevaplar.Select(a=> new KopekDegerlendirmeCevaplarResponse
                        {
                            SoruAdi=a.KopekDegerlendirmeSoru.Name,
                            AracCevap=a.AracPuan,
                            KapaliAlanCevap=a.KapaliAlanPuan,
                            TasinabilirEsyaCevap=a.TasinabilirEsyaPuan
                        }).ToList(),
                        KursiyerDegerlendirmeCevaplar=k.KursiyerDegerlendirmeCevaplar.Select(a=>new KursiyerDegerlendirmeCevaplarResponse
                        {
                            SoruAdi=a.KursiyerDegerlendirmeSoru.Name,
                            AracCevap=a.AracPuan,
                            KapaliAlanCevap=a.KapaliAlanPuan,
                            TasinabilirEsyaCevap=a.TasinabilirEsyaPuan
                        }).ToList(),
                        KopekAracToplamPuan=k.KopekDegerlendirmeCevaplar.Sum(a=>a.AracPuan),
                        KopekTasinabilirEsyaToplamPuan=k.KopekDegerlendirmeCevaplar.Sum(a=>a.TasinabilirEsyaPuan),
                        KopekKapaliAlanToplamPuan=k.KopekDegerlendirmeCevaplar.Sum(a=>a.KapaliAlanPuan),
                        KursiyerAracToplamPuan=k.KursiyerDegerlendirmeCevaplar.Sum(a=>a.AracPuan),
                        KursiyerKapaliAlanToplamPuan=k.KursiyerDegerlendirmeCevaplar.Sum(a=>a.KapaliAlanPuan),
                        KursiyerTasinabilirEsyaToplamPuan=k.KursiyerDegerlendirmeCevaplar.Sum(a=>a.TasinabilirEsyaPuan)
                        
                    }).ToListAsync();

                if (kopekVeIdareciDegerlendirme == null)
                {
                    return Result<List<KopekVeKursiyerDegerlendirmeFormuGetirResponse>>.Fail("Kursa dair bir değerlendirme bulunamadı..");
                }
                return Result<List<KopekVeKursiyerDegerlendirmeFormuGetirResponse>>.Success(kopekVeIdareciDegerlendirme);
            }
        }
    }

    public class GetKopekVeKursiyerDegerlendirmeFormuByKursIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/GetKopekVeKursiyerDegerlendirmeFormuByKursId", async (int kursId, ISender sender) =>
            {
                var request = new GetKopekVeKursiyerDegerlendirmeFormuByKursId.Query(kursId);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
