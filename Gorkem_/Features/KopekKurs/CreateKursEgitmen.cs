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
    public static class CreateKursEgitmen
    {
        public record Command(KursEgitmenEkleRequest Request) : IRequest<Result<bool>>
        {

        }

        public class CreateKursEgitmenValidation : AbstractValidator<Command>
        {
            public CreateKursEgitmenValidation()
            {
                RuleFor(r => r.Request.RutbeId).NotNull().NotEmpty().WithMessage("Kurs eğitmeninin rütbesi boş olmaz..");
                RuleFor(r => r.Request.BirimId).NotNull().NotEmpty().WithMessage("Kurs eğitmeninin birimi boş olmaz..");
                RuleFor(r => r.Request.AdSoyad).NotNull().NotEmpty().WithMessage("Kurs eğitmeninin Ad-Soyadı boş olmaz..");
                RuleFor(r => r.Request.Sicil).NotNull().NotEmpty().WithMessage("Kurs eğitmeninin sicili boş olmaz..");

            }

        }
        public static UT_KursEgitmenler ToKursEgitmenler(this Command command)
        {
            return new UT_KursEgitmenler()
            {
                AdSoyad = command.Request.AdSoyad,
                BirimId = command.Request.BirimId,
                RutbeId = command.Request.RutbeId,
                Sicil = command.Request.Sicil,
                Aktifmi = true,
                T_Aktif=DateTime.Now,
                
            };

        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_KursEgitmenler.Any(r => r.Sicil == request.Request.Sicil);
                if (isExist) return await Result<bool>.FailAsync($"{request.Request.Sicil} is already exist");

                Context.UT_KursEgitmenler.Add(request.ToKursEgitmenler());

                var isSaved = await Context.SaveChangesAsync() > 0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} zamanında eklendi", request.Request.Sicil, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Kayıt başarılı değil");

            }
        }
    }

    public class CreateKursEgitmenEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/CreateKursEgitmen", async ([FromBody] KursEgitmenEkleRequest model, ISender sender) =>
            {
                var request = new CreateKursEgitmen.Command(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
