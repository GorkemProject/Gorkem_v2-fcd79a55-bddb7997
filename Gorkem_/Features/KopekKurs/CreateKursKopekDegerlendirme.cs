using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using Gorkem_.Features.KodTablo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.KopekKurs
{
    public static class CreateKursKopekDegerlendirme
    {
        public record Command (KopekKursDegerlendirmeEkleRequest Request) : IRequest<Result<int>>;

        public class CreateKursKopekDegerlenirmeValidation : AbstractValidator<Command>
        {
            public CreateKursKopekDegerlenirmeValidation()
            {

                RuleFor(r => r.Request.KopekDegerlendirmeSoruId).NotEmpty().NotNull().WithMessage("Hangi soru olduğunu seçmelisiniz");
                RuleFor(r => r.Request.KapaliAlanPuan).NotEmpty().NotNull().WithMessage("Hangi puan olduğunu seçmelisiniz");
                RuleFor(r => r.Request.AracPuan).NotEmpty().NotNull().WithMessage("Hangi soru olduğunu seçmelisiniz");
                RuleFor(r => r.Request.TasinabilirEsyaPuan).NotEmpty().NotNull().WithMessage("Hangi soru olduğunu seçmelisiniz");
                RuleFor(r => r.Request.KopekId).NotEmpty().NotNull().WithMessage("Hangi köpek olduğunu seçmelisiniz");

            }
        }

        public static UT_KursKopekDegerlendirmeCevap ToKursKopekDegerlendirmeCevap(this Command command)
        {
            return new UT_KursKopekDegerlendirmeCevap
            {
                Aktifmi = true,
                T_Aktif=DateTime.Now,
                AracPuan=command.Request.AracPuan,
                KapaliAlanPuan=command.Request.KapaliAlanPuan,
                TasinabilirEsyaPuan = command.Request.TasinabilirEsyaPuan,
                KopekDegerlendirmeSoruId = command.Request.KopekDegerlendirmeSoruId,
                KopekId= command.Request.KopekId,
            };
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<int>>
        {
            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_KursKopekDegerlendirmeCevap.Any(x => x.Id==request.Request.Id);
                if (isExist) return await Result<int>.FailAsync($"{request.Request.Id} numaralı test zaten var");

                Context.UT_KursKopekDegerlendirmeCevap.Add(request.ToKursKopekDegerlendirmeCevap());
                var isSaved = await Context.SaveChangesAsync() > 0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} tarihinde eklendi..", request.Request.Id, "DemoAccount", DateTime.Now);
                    return await Result<int>.SuccessAsync();

                }
                return await Result<int>.FailAsync("Kayıt başarılı değil");

            }
        }
    }

    public class CreateKursKopekDegerlendirmeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/CreateKopekKursDegerlendirme", async ([FromBody] KopekKursDegerlendirmeEkleRequest model, ISender sender) =>
            {
                var request = new CreateKursKopekDegerlendirme.Command(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
