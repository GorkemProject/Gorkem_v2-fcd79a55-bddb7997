
using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using Gorkem_.Migrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Gorkem_.Features.KopekKurs.CreateKopekVeKursiyerDegerlendirneFormu;

namespace Gorkem_.Features.KopekKurs
{
    public static class CreateKopekVeKursiyerDegerlendirneFormu
    {

        public record KursiyerKopekDegerlendirmeEkleCommand(KopekVeIdareciDegerlendirmeFormuRequest Request) : IRequest<Result<int>>;

        public class CreateKopekVeKursiyerDegerlendirmeFormuValidation : AbstractValidator<KursiyerKopekDegerlendirmeEkleCommand>
        {
            public CreateKopekVeKursiyerDegerlendirmeFormuValidation()
            {
                RuleFor(r => r.Request.KursId).NotEmpty().WithMessage("Kurs ID'si belirtilmelidir.");
                RuleFor(r => r.Request.TarihSaat).NotEmpty().WithMessage("Tarih ve saat belirtilmelidir.");
                RuleFor(r => r.Request.TestinYapildigiIlId).NotEmpty().WithMessage("Testin yapıldığı il belirtilmelidir.");


            }
        }


    }

    internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<KursiyerKopekDegerlendirmeEkleCommand, Result<int>>
    {
        public async Task<Result<int>> Handle(KursiyerKopekDegerlendirmeEkleCommand request, CancellationToken cancellationToken)
        {
            var isExist = Context.UT_KopekVeIdareciDegerlendirmeFormu
                .Any(r => r.Id == request.Request.Id);
            if (isExist) return await Result<int>.FailAsync("Bu kurs ve tarihe ait bir değerlendirme zaten mevcut.");

 

            var toplamKopekPuan = 0;
            var toplamKursiyerPuan = 0;
            int kursiyerId = 0;

            foreach (var cevap in request.Request.KursDegerlendirmeCevaplar)
            {
                // Köpek için puanları toplama
                if (cevap.DegerlendirmeTuru == 1)
                {
                    toplamKopekPuan += (cevap.KapaliAlanPuan + cevap.AracPuan + cevap.TasinabilirEsyaPuan)/3;
                }

                // Kursiyer için puanları toplama ve kursiyer ID'sini alma
                if (cevap.DegerlendirmeTuru == 2)
                {
                    toplamKursiyerPuan += (cevap.KapaliAlanPuan + cevap.AracPuan + cevap.TasinabilirEsyaPuan)/3;
                    kursiyerId = cevap.KursiyerId;  // Kursiyer ID'sini alıyoruz
                }
            }



            var cevaplar =

                new UT_KopekVeIdareciDegerlendirmeFormu
                {
                    Aktifmi = true,
                    T_Aktif = DateTime.Now,
                    KursId = request.Request.KursId,
                    TarihSaat = request.Request.TarihSaat,
                    TestinYapildigiIlId = request.Request.TestinYapildigiIlId,
                    TestinYapildigiYer = request.Request.TestinYapildigiYer,
                    KursDegerlendirmeCevaplar = request.Request.KursDegerlendirmeCevaplar
            .Select(c => new UT_KursDegerlendirmeCevap
            {
                DegerlendirmeSoruId = c.DegerlendirmeSoruId,
                KapaliAlanPuan = c.KapaliAlanPuan,
                AracPuan = c.AracPuan,
                TasinabilirEsyaPuan = c.TasinabilirEsyaPuan,
                DegerlendirmeTuru = c.DegerlendirmeTuru,
                KursiyerId = c.DegerlendirmeTuru == 2 ? c.KursiyerId : Context.UT_Kursiyer.FirstOrDefault(b => b.KopekId == c.KursiyerId).Id,
                Aktifmi = true,
                KursId = c.KursId,
                T_Aktif = DateTime.Now
                
            }).ToList()
                };


            Context.UT_KopekVeIdareciDegerlendirmeFormu.Add(cevaplar);

            var kursiyer = Context.UT_Kursiyer.Include(k => k.Kopek).FirstOrDefault(k => k.Id == kursiyerId);
            if (kursiyer != null)
            {
                kursiyer.KursiyerToplamPuan = toplamKursiyerPuan;  // Kursiyer toplam puanını güncelle
                kursiyer.KopekToplamPuan = toplamKopekPuan;
            }

            if (kursiyer.KopekToplamPuan > 70)
            {
                kursiyer.Kopek.KopekDurum = Enums.Enum_KopekDurum.KursOlumlu;
            }
            else
            {
                kursiyer.Kopek.KopekDurum = Enums.Enum_KopekDurum.KursRed;

            }


            var isSaved = await Context.SaveChangesAsync() > 0;
            if (isSaved)
            {
                Logger.Information("Kurs ID {0} değerlendirmesi başarıyla kaydedildi.", request.Request.Id);
                return await Result<int>.SuccessAsync(request.Request.Id);
            }


            return await Result<int>.FailAsync("Kayıt sırasında bir hata oluştu.");
        }
    }
}
public class CreateKopekVeKursiyerDegerlendirneFormuEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("kopekKurs/CreateKopekVeKursiyerDegerlendirneFormu", async ([FromBody] KopekVeIdareciDegerlendirmeFormuRequest model, ISender sender) =>
        {
            var request = new KursiyerKopekDegerlendirmeEkleCommand(model);
            var response = await sender.Send(request);

            if (response.Succeeded)
                return Results.Ok(response);
            return Results.BadRequest(response);


        }).WithTags(EndpointConstants.KOPEKKURS);
    }
}
