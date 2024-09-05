using AspNetCoreHero.Results;
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
            
            public int IrkRef { get; set; }
            public int BirimRef { get; set; }
            public int BransRef { get; set; }
            public int KuvveNumarasi { get; set; }
            public int CipNumarasi { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string? YapilanIslem { get; set; }
            public string? NihaiKanaat { get; set; }
            public int KopekTuruRef { get; set; }
            public bool Karar { get; set; }
            public int DurumRef { get; set; }
            public string? TeminSekli { get; set; }

        }
        public class CreateKopekValidation : AbstractValidator<Command>
        {
            public CreateKopekValidation()
            {// string degerler null check yapalım
             // integer degerler de greaterthen(0) uygulayalım
             // tarih alanlarında valid bir datetime check yapalım
                
                RuleFor(r => r.IrkRef).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
                RuleFor(r => r.BirimRef).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
                RuleFor(r => r.BransRef).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
                RuleFor(r => r.KuvveNumarasi).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
                RuleFor(r => r.CipNumarasi).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
                RuleFor(r => r.DogumTarihi).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
                RuleFor(r => r.YapilanIslem).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
                RuleFor(r => r.NihaiKanaat).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
                RuleFor(r => r.KopekTuruRef).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
                RuleFor(r => r.Karar).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
                RuleFor(r => r.DurumRef).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
                RuleFor(r => r.TeminSekli).NotEmpty().NotNull().WithMessage("İsim Değeri Boş Olamaz");
            }
        }
        public static UT_Kopek ToKopek(this Command command)
        {
            return new UT_Kopek
            {
              
                IrkId = command.IrkRef,
                BirimId = command.BirimRef,
                BransId = command.BransRef,
                KuvveNumarasi = command.KuvveNumarasi,
                CipNumarasi = command.CipNumarasi,
                DogumTarihi = command.DogumTarihi,
                YapilanIslem = command.YapilanIslem,
                NihaiKanaat = command.NihaiKanaat,
                KopekTuruId = command.KopekTuruRef,
                Karar = command.Karar,
                DurumId = command.DurumRef,
                TeminSekli = command.TeminSekli,
                T_Aktif = DateTime.Now,
                Aktifmi = true

            };

        }
        internal sealed class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly GorkemDbContext _context;
            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = _context.UT_Kopek_Kopeks.Any(r=>r.CipNumarasi ==request.CipNumarasi);
                if (isExist) return await Result<bool>.FailAsync($"{request.CipNumarasi} is already exist");

                _context.UT_Kopek_Kopeks.Add(request.ToKopek());
                var isSaved = await _context.SaveChangesAsync() > 0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
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
                   
                    IrkRef = model.IrkRef,
                    BirimRef = model.BirimRef,
                    BransRef = model.BransRef,
                    KuvveNumarasi = model.KuvveNumarasi,
                    CipNumarasi = model.CipNumarasi,
                    DogumTarihi = model.DogumTarihi,
                    YapilanIslem = model.YapilanIslem,
                    NihaiKanaat = model.NihaiKanaat,
                    KopekTuruRef = model.KopekTuruRef,
                    Karar = model.Karar,
                    DurumRef = model.DurumRef,
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
