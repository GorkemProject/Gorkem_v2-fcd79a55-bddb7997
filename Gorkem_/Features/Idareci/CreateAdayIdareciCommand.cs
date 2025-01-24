using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Idareci; 
using Gorkem_.EndpointTags;
using Gorkem_.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Idareci
{
    public record CreateAdayIdareciCommand(IdareciEkleRequest Idareci) : IRequest<Result<bool>>;

    internal sealed class CreateIdareciCommandHandler : IRequestHandler<CreateAdayIdareciCommand, Result<bool>>
    {
        private readonly GorkemDbContext context;

        public CreateIdareciCommandHandler(GorkemDbContext context)
        {
            this.context = context;
        }

        public async Task<Result<bool>> Handle(CreateAdayIdareciCommand request, CancellationToken cancellationToken)
        {
            bool isExists = await context.UT_AdayIdareci.AnyAsync(x => x.Sicil.Equals(request.Idareci.Sicil));

            if (isExists)
                return await Result<bool>.FailAsync("Bu sicilde idareci zaten kayıtlı");

            //puana göre durum atama
            Enum_AdayPersonelDurum durum = request.Idareci.Puan >= 80 ? Enum_AdayPersonelDurum.Basarili : Enum_AdayPersonelDurum.Basarisiz;

            UT_AdayIdareci idareci = new UT_AdayIdareci()
            {
                AdSoyad = request.Idareci.AdSoyad,
            
                AskerlikId = request.Idareci.AskerlikId,
                Aktifmi = true,
               
                KadroIlId = request.Idareci.KadroIlId, 
                BransId = request.Idareci.BransId,
                CepTelefonu = request.Idareci.CepTelefonu,
                DogumTarihi = request.Idareci.DogumTarihi, 
                IdareciDurumId = request.Idareci.IdareciDurumId,  
                RutbeId = request.Idareci.RutbeId,
                Sicil = request.Idareci.Sicil, 
                T_Aktif = DateTime.Now,
                Puan=request.Idareci.Puan,
                TestiYapanSicil=request.Idareci.TestiYapanSicil,
                TestTarihi= request.Idareci.TestTarihi,
                Durum = durum,
                
                
            };
            await context.UT_AdayIdareci.AddAsync(idareci);
            int result = await context.SaveChangesAsync();
            
            if (result > 0)
                return await Result<bool>.SuccessAsync();

            return await Result<bool>.FailAsync("Kayıt işlemi başarısız");
        }
    }

    public class CreateAdayIdareciEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("idareci/createAdayIdareci", async ([FromBody] IdareciEkleRequest request, ISender sender) =>
            {
                var response = await sender.Send(new CreateAdayIdareciCommand(request));

                if (response.Succeeded)
                    return Results.Ok(response);

                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.IDARECI);
        }
    }

    public class CreateIdareciCommandValidator : AbstractValidator<CreateAdayIdareciCommand>
    {
        public CreateIdareciCommandValidator()
        {
            RuleFor(r => r.Idareci.Sicil)
                .NotEmpty()
                .NotNull()
                .GreaterThan(90000)
                .WithMessage("Sicil değeri hatalı");

            RuleFor(r => r.Idareci.AdSoyad)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ad soyad değeri boş olamaz");

            RuleFor(r => r.Idareci.RutbeId)
              .GreaterThan(0)
                .WithMessage("Rütbe değeri boş olamaz");

            RuleFor(r => r.Idareci.KadroIlId)
                .GreaterThan(0)
                .WithMessage("Birim değeri boş olamaz");

            RuleFor(r => r.Idareci.BransId)
                .GreaterThan(0)
                .WithMessage("Branş değeri boş olamaz");

            RuleFor(r => r.Idareci.CepTelefonu)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cep telefonu değeri boş olamaz");

            RuleFor(r => r.Idareci.AskerlikId)
              .GreaterThan(0)
                .WithMessage("Askerlik durumu değeri boş olamaz");

            RuleFor(r => r.Idareci.IdareciDurumId)
             .GreaterThan(0)
                .WithMessage("Durum değeri boş olamaz");

            RuleFor(r => r.Idareci.DogumTarihi)
                .NotEmpty()
                .Must(ValidateAge)
                .WithMessage("Doğum tarihi değeri hatalı");
        }

        private bool ValidateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (age >= 18 && age <= 65)
                return true;
            return false;
        }
    }
}
