using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Kopek;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gorkem_.Features.Kopek
{
    public static class CreateKopek
    {
        public record Command(KopekEkleRequest Request) : IRequest<Result<bool>>
        {
            ////Parametrelerimizi buraya yazıyoruz.
            //public string KopekAdi { get; set; }
            //public int IrkId { get; set; }
            //public string KuvveNumarasi { get; set; }
            //public int KadroIlId { get; set; }
            //public int BransId { get; set; }
            //public string CipNumarasi { get; set; }
            //public DateTime DogumTarihi { get; set; }
            //public string? YapilanIslem { get; set; }
            //public string? NihaiKanaat { get; set; }
            //public int KararId { get; set; }

        }
        public class CreateKopekValidation : AbstractValidator<Command>
        {
            public CreateKopekValidation()
            {// string degerler null check yapalım
             // integer degerler de greaterthen(0) uygulayalım
             // tarih alanlarında valid bir datetime check yapalım
                RuleFor(r => r.Request.KopekAdi).NotEmpty().NotNull().WithMessage("Köpek ismi boş olamaz");
                RuleFor(r => r.Request.IrkId).NotEmpty().NotNull().WithMessage("Irk Değeri Boş Olamaz");
                RuleFor(r => r.Request.KadroIlId).NotEmpty().NotNull().WithMessage("Birim Değeri Boş Olamaz");
                RuleFor(r => r.Request.BransId).NotEmpty().NotNull().WithMessage("Branş Değeri Boş Olamaz");
                RuleFor(r => r.Request.CipNumarasi).NotEmpty().NotNull().WithMessage("Çip Numarası Değeri Boş Olamaz");
                RuleFor(r => r.Request.DogumTarihi).NotEmpty().NotNull().WithMessage("Doğum Tarihi Değeri Boş Olamaz");
                RuleFor(r => r.Request.YapilanIslem).NotEmpty().NotNull().WithMessage("Yapılan işlem Değeri Boş Olamaz");
                RuleFor(r => r.Request.NihaiKanaat).NotEmpty().NotNull().WithMessage("Nihai Kanat Değeri Boş Olamaz");
                RuleFor(r => r.Request.KararId).NotEmpty().NotNull().WithMessage("Karar Değeri Boş Olamaz");


            }
        }
        public static UT_Kopek ToKopek(this Command command)
        {
            return new UT_Kopek
            {
                KopekAdi = command.Request.KopekAdi,
                IrkId = command.Request.IrkId,
                KadroIlId = command.Request.KadroIlId,
                BransId = command.Request.BransId,
                CipNumarasi = command.Request.CipNumarasi,
                DogumTarihi = command.Request.DogumTarihi,
                YapilanIslem = command.Request.YapilanIslem,
                NihaiKanaat = command.Request.NihaiKanaat,
                KuvveNumarasi = command.Request.KuvveNumarasi,
                KararId = command.Request.KararId,
                T_Aktif = DateTime.Now,
                Aktifmi = true,
                Cinsiyet=command.Request.Cinsiyet,
                EdinimSekli=command.Request.EdinimSekli,
                AnneKopekId=command.Request.AnneKopekId,
                BabaKopekId=command.Request.BabaKopekId,
                EdinilenKisi=command.Request.EdinilenKisi,
                EdinilenKisiAdres=command.Request.EdinilenKisiAdres,
                EdinilenKisiTelefon=command.Request.EdinilenKisiTelefon,
                EdinilmeTarihi=command.Request.EdinilmeTarihi
                
                
            };

        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {


            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_Kopek_Kopeks.Any(r => r.CipNumarasi == request.Request.CipNumarasi);
                if (isExist) return await Result<bool>.FailAsync($"{request.Request.CipNumarasi} is already exist");
                var ss = request.ToKopek();
                Context.UT_Kopek_Kopeks.Add(request.ToKopek());
                var isSaved = await Context.SaveChangesAsync() > 0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} Zamanında Eklendi", request.Request.CipNumarasi, "DemoAccount", DateTime.Now);
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
                var request = new CreateKopek.Command(model);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response.Message);


            }).WithTags(EndpointConstants.KOPEK);
        }
    }
}
