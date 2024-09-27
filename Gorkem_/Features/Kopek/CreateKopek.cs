﻿using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Kopek;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gorkem_.Features.Kopek
{
    public static class CreateKopek
    {
        public class Command : IRequest<Result<bool>>
        {
            //Parametrelerimizi buraya yazıyoruz.
            public string KopekAdi { get; set; }
            public int IrkId { get; set; }
            public int CinsId { get; set; }

            public int BirimId { get; set; }
            public int BransId { get; set; }
            public int KuvveNumarasi { get; set; }
            public int CipNumarasi { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string? YapilanIslem { get; set; }
            public string? NihaiKanaat { get; set; }
            public int KopekTuruId { get; set; }
            public bool Karar { get; set; }
            public int KopekDurumId { get; set; }
            public int TeminSekli { get; set; }

        }
        public class CreateKopekValidation : AbstractValidator<Command>
        {
            public CreateKopekValidation()
            {// string degerler null check yapalım
             // integer degerler de greaterthen(0) uygulayalım
             // tarih alanlarında valid bir datetime check yapalım
                RuleFor(r  => r.KopekAdi).NotEmpty().NotNull().WithMessage("Köpek ismi boş olamaz");
                RuleFor(r => r.IrkId).NotEmpty().NotNull().WithMessage("Irk Değeri Boş Olamaz");
                RuleFor(r => r.BirimId).NotEmpty().NotNull().WithMessage("Birim Değeri Boş Olamaz");
                RuleFor(r => r.BransId).NotEmpty().NotNull().WithMessage("Branş Değeri Boş Olamaz");
                RuleFor(r => r.KuvveNumarasi).NotEmpty().NotNull().WithMessage("Kuvve Numarası Değeri Boş Olamaz");
                RuleFor(r => r.CipNumarasi).NotEmpty().NotNull().WithMessage("Çip Numarası Değeri Boş Olamaz");
                RuleFor(r => r.DogumTarihi).NotEmpty().NotNull().WithMessage("Doğum Tarihi Değeri Boş Olamaz");
                RuleFor(r => r.YapilanIslem).NotEmpty().NotNull().WithMessage("Yapılan işlem Değeri Boş Olamaz");
                RuleFor(r => r.NihaiKanaat).NotEmpty().NotNull().WithMessage("Nihai Kanat Değeri Boş Olamaz");
                RuleFor(r => r.KopekTuruId).NotEmpty().NotNull().WithMessage("Kopek Turu  Değeri Boş Olamaz");
                RuleFor(r => r.Karar).NotEmpty().NotNull().WithMessage("Karar Değeri Boş Olamaz");
                RuleFor(r => r.KopekDurumId).NotEmpty().NotNull().WithMessage("Durum Değeri Boş Olamaz");
                RuleFor(r => r.TeminSekli).NotEmpty().NotNull().WithMessage("Temin Şekli Değeri Boş Olamaz");
                RuleFor(r => r.CinsId).NotEmpty().NotNull().WithMessage("Cins Değeri Boş Olamaz");
                
            }
        }
        public static UT_Kopek ToKopek(this Command command)
        {
            return new UT_Kopek
            {
                KopekAdi = command.KopekAdi,
                IrkId = command.IrkId,
                BirimId = command.BirimId,
                BransId = command.BransId,
                KuvveNumarasi = command.KuvveNumarasi,
                CinsId = command.CinsId,
                CipNumarasi = command.CipNumarasi,
                DogumTarihi = command.DogumTarihi,
                YapilanIslem = command.YapilanIslem,
                NihaiKanaat = command.NihaiKanaat,
                KopekTuruId = command.KopekTuruId,
                Karar = command.Karar,
                KopekDurumId = command.KopekDurumId,
                TeminSekli = command.TeminSekli,
                T_Aktif = DateTime.Now,
                Aktifmi = true

            };

        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
 

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_Kopek_Kopeks.Any(r=>r.CipNumarasi ==request.CipNumarasi);
                if (isExist) return await Result<bool>.FailAsync($"{request.CipNumarasi} is already exist");

                Context.UT_Kopek_Kopeks.Add(request.ToKopek());
                var isSaved = await Context.SaveChangesAsync() > 0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} Zamanında Eklendi", request.KuvveNumarasi, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Kayıt Başarılı Değil");

            }
        }
    }
    public class CreateKopekEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopek", async ([FromBody] KopekEkleRequest model, ISender sender) =>
            {
                var request = new CreateKopek.Command() 
                {
                    KopekAdi = model.KopekAdi,
                    IrkId = model.IrkId,
                    BirimId = model.BirimId,
                    BransId = model.BransId,
                    CinsId = model.CinsId,
                    KuvveNumarasi = model.KuvveNumarasi,
                    CipNumarasi = model.CipNumarasi,
                    DogumTarihi = model.DogumTarihi,
                    YapilanIslem = model.YapilanIslem,
                    NihaiKanaat = model.NihaiKanaat,
                    KopekTuruId = model.KopekTuruId,
                    Karar = model.Karar,
                    KopekDurumId = model.KopekDurumId,
                    TeminSekli = model.TeminSekli,
                };
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok();
                return Results.BadRequest(response.Message);


            }).WithTags(EndpointConstants.KOPEK);
        }
    }
}
