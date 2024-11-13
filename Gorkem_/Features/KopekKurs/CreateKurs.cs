using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.KopekKurs
{
    public static class CreateKurs
    {
        public record Command(KursEkleRequest Request) : IRequest<Result<bool>>
        {

        }
        public class CreateKursValidation : AbstractValidator<Command>
        {
            public CreateKursValidation()
            {
                RuleFor(r=>r.Request.KursYeriId).NotEmpty().NotNull().WithMessage("Kurs yeri boş bırakılamaz");
                RuleFor(r=>r.Request.KursEgitimListesiId).NotEmpty().NotNull().WithMessage("Yapılacak kurs boş bırakılamaz");
                RuleFor(r=>r.Request.T_KursBaslangic).NotEmpty().NotNull().WithMessage("Kurs başlangıç tarihi boş bırakılamaz");
                RuleFor(r=>r.Request.T_KursBitis).NotEmpty().NotNull().WithMessage("Kurs bitiş tarihi boş bırakılamaz");
                RuleFor(r=>r.Request.Donem).NotEmpty().NotNull().WithMessage("Kurs dönemi boş bırakılamaz");

            }
        }

        public static UT_Kurs ToKurs(this Command command)
        {
            return new UT_Kurs
            {
                T_KursBaslangic = command.Request.T_KursBaslangic,
                T_KursBitis = command.Request.T_KursBitis,
                Donem = command.Request.Donem,
                KursEgitimListesiId = command.Request.KursEgitimListesiId,
                Aktifmi = true,
                KursYeriId = command.Request.KursYeriId,
                T_Aktif = DateTime.Now
                
            };
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_Kurs.Any(r => r.Id == request.Request.Id);
                if (isExist) return await Result<bool>.FailAsync($"{request.Request.Id} is already exist");

                Context.UT_Kurs.Add(request.ToKurs());

                var isSaved = await Context.SaveChangesAsync()>0;

                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} tarihinde eklendi", request.Request.KursEgitimListesiId, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Kayıt başarılı değil");
            }
        }
    }
    public class CreateKursEndponit : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/CreateKopekKurs", async ([FromBody] KursEkleRequest model, ISender sender) =>
            {
                var request = new CreateKurs.Command(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
