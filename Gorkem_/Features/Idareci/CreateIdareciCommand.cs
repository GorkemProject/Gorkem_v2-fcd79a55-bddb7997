using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Idareci; 
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Idareci
{
    public record CreateIdareciCommand(IdareciEkleRequest Idareci) : IRequest<Result<bool>>;

    internal sealed class CreateIdareciCommandHandler : IRequestHandler<CreateIdareciCommand, Result<bool>>
    {
        private readonly GorkemDbContext context;

        public CreateIdareciCommandHandler(GorkemDbContext context)
        {
            this.context = context;
        }

        public async Task<Result<bool>> Handle(CreateIdareciCommand request, CancellationToken cancellationToken)
        {
            bool isExists = await context.UT_Idarecis.AnyAsync(x => x.Sicil.Equals(request.Idareci.Sicil));

            if (isExists)
                return await Result<bool>.FailAsync("Bu sicilde idareci zaten kayıtlı");

            UT_Idareci idareci = new UT_Idareci()
            {
                AdSoyad = request.Idareci.AdSoyad,
                Askerlik = request.Idareci.Askerlik,
                AskerlikId = request.Idareci.AskerlikId,
                Aktifmi = true,
                Birim = request.Idareci.Birim,
                BirimId = request.Idareci.BirimId,
                Brans = request.Idareci.Brans,
                BransId = request.Idareci.BransId,
                CepTelefonu = request.Idareci.CepTelefonu,
                DogumTarihi = request.Idareci.DogumTarihi,
                IdareciDurum = request.Idareci.IdareciDurum,
                IdareciDurumId = request.Idareci.IdareciDurumId,
                OgrenimDurumu = request.Idareci.OgrenimDurumu,
                Rutbe = request.Idareci.Rutbe,
                RutbeId = request.Idareci.RutbeId,
                Sicil = request.Idareci.Sicil,
                YabanciDil = request.Idareci.YabanciDil,
                T_Aktif = DateTime.Now,
            };

            await context.AddAsync(idareci);
            int result = await context.SaveChangesAsync();

            if (result > 0)
                return await Result<bool>.SuccessAsync();

            return await Result<bool>.FailAsync("Kayıt işlemi başarısız");
        }
    }

    public class CreateIdareciEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("idareci", async ([FromBody] IdareciEkleRequest request, ISender sender) =>
            {
                var response = await sender.Send(new CreateIdareciCommand(request));

                if (response.Succeeded)
                    return Results.Ok();

                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.IDARECI);
        }
    }

    public class CreateIdareciCommandValidator : AbstractValidator<CreateIdareciCommand>
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

            RuleFor(r => r.Idareci.Rutbe)
                .NotEmpty()
                .NotNull()
                .WithMessage("Rütbe değeri boş olamaz");

            RuleFor(r => r.Idareci.Birim)
                .NotEmpty()
                .NotNull()
                .WithMessage("Birim değeri boş olamaz");

            RuleFor(r => r.Idareci.Brans)
                .NotEmpty()
                .NotNull()
                .WithMessage("Branş değeri boş olamaz");

            RuleFor(r => r.Idareci.CepTelefonu)
                .NotEmpty()
                .NotNull()
                .WithMessage("Cep telefonu değeri boş olamaz");

            RuleFor(r => r.Idareci.Askerlik)
                .NotEmpty()
                .NotNull()
                .WithMessage("Askerlik durumu değeri boş olamaz");

            RuleFor(r => r.Idareci.IdareciDurum)
                .NotEmpty()
                .NotNull()
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
