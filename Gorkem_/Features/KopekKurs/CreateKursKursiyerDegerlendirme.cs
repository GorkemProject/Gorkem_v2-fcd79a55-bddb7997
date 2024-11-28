using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace Gorkem_.Features.KopekKurs
{
    public static class CreateKursKursiyerDegerlendirme
    {

        public record Command(KursiyerKursDegerlendirmeEkleRequest Request) : IRequest<Result<int>>;

        public class CreateKursKursiyerDegerlendirmeValidation : AbstractValidator<Command>
        {
            public CreateKursKursiyerDegerlendirmeValidation()
            {
                RuleFor(r => r.Request.KursiyerDegerlendirmeSoruId).NotNull().NotEmpty().WithMessage("Hangi soru olduğunu seçmelisiniz");
                RuleFor(r => r.Request.KursiyerId).NotNull().NotEmpty().WithMessage("Hangi kursiyer olduğunu seçmelisiniz");
                RuleFor(r => r.Request.KapaliAlanPuan).NotNull().NotEmpty().WithMessage("Kapalı alan puanını boş geçemezsiniz");
                RuleFor(r => r.Request.AracPuan).NotNull().NotEmpty().WithMessage("Araç puanını boş geçemezsiniz");
                RuleFor(r => r.Request.TasinabilirEsyaPuan).NotNull().NotEmpty().WithMessage("Taşınabilir eşya puanını boş geçemezsiniz");
            }
        }

        public static UT_KursKursiyerDegerlendirmeCevap ToKursKursiyerDegerlendirmeCevap(this Command command)
        {
            return new UT_KursKursiyerDegerlendirmeCevap
            {
                Aktifmi = true,
                T_Aktif=DateTime.Now,
                AracPuan=command.Request.AracPuan,
                KapaliAlanPuan=command.Request.KapaliAlanPuan,
                TasinabilirEsyaPuan = command.Request.TasinabilirEsyaPuan,
                KursiyerDegerlendirmeSoruId = command.Request.KursiyerDegerlendirmeSoruId,
                KursiyerId = command.Request.KursiyerId,
                
            };
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<int>>
        {
            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_KursKursiyerDegerlendirmeCevap.Any(x => x.Id == request.Request.Id);
                if (isExist) return await Result<int>.FailAsync($"{request.Request.Id} numaralı test zaten var");

                Context.UT_KursKursiyerDegerlendirmeCevap.Add(request.ToKursKursiyerDegerlendirmeCevap());
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

    public class CreateKursKursiyerDegerlendirmeValidation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/createKursiyerKursDegerlendirme", async ([FromBody] KursiyerKursDegerlendirmeEkleRequest model, ISender sender) =>
            {
                var request = new CreateKursKursiyerDegerlendirme.Command(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
