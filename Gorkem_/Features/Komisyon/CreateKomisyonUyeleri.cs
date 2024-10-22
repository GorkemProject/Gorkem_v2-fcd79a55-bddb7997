using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace Gorkem_.Features.Komisyon
{
    public static class CreateKomisyonUyeleri
    {
        public record Command(KomisyonUyeEkleRequest Request) : IRequest<Result<bool>>
        {

        }

        public class CreateKomisyonUyeleriValidation : AbstractValidator<Command>
        {
            public CreateKomisyonUyeleriValidation()
            {
                RuleFor(r => r.Request.TcKimlikNo).NotEmpty().NotNull().WithMessage("Komisyon üyesinin TC Kimlik numarası boş bırakılamaz.");
                RuleFor(r => r.Request.AdSoyad).NotEmpty().NotNull().WithMessage("Komisyon üyesinin Ad ve Soyadı boş bırakılamaz.");
                RuleFor(r => r.Request.GorevUnvani).NotEmpty().NotNull().WithMessage("Komisyon üyesinin Görev Ünvanı boş bırakılamaz.");
                RuleFor(r => r.Request.GorevYeri).NotEmpty().NotNull().WithMessage("Komisyon üyesinin Görev Yeri boş bırakılamaz.");
                RuleFor(r => r.Request.Eposta).NotEmpty().NotNull().WithMessage("Komisyon üyesinin Eposta Adresi boş bırakılamaz.");
                RuleFor(r => r.Request.CepTelefonu).NotEmpty().NotNull().WithMessage("Komisyon üyesinin Telefon Numarası boş bırakılamaz.");
            }
        }
        public static UT_KomisyonUyeleri ToKomisyonUyeleri(this Command command)
        {
            return new UT_KomisyonUyeleri
            {
                TcKimlikNo = command.Request.TcKimlikNo,
                AdSoyad = command.Request.AdSoyad,
                Sicil = command.Request.Sicil,
                GorevUnvani = command.Request.GorevUnvani,
                GorevYeri = command.Request.GorevYeri,
                Eposta = command.Request.Eposta,
                CepTelefonu = command.Request.CepTelefonu,
                T_Aktif = DateTime.Now,
                Aktifmi = true

            };
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_KomisyonUyeleris.Any(r=>r.TcKimlikNo ==request.Request.TcKimlikNo);
                if (isExist) return await Result<bool>.FailAsync($"{request.Request.TcKimlikNo} is already exist");

                Context.UT_KomisyonUyeleris.Add(request.ToKomisyonUyeleri());
                var isSaved = await Context.SaveChangesAsync()>0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} zamanında eklendi", request.Request.TcKimlikNo, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Kayıt başarılı değil");
            }
        }
    }
    public class CreateKomisyonUyeleriEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("komisyonUyeleri/createKomisyonUye", async ([FromBody] KomisyonUyeEkleRequest model, ISender sender) =>
            {
                var request = new CreateKomisyonUyeleri.Command(model);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
