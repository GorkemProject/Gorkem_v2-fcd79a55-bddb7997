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
    public static class CreateKursGunlukRapor
    {
        public record Command(KursGunlukRaporEkleRequest Request) : IRequest<Result<bool>>
        {

        }
        public class CreateKursGunlukRaporValidation : AbstractValidator<Command>
        {
            public CreateKursGunlukRaporValidation()
            {
                RuleFor(r => r.Request.KursId).NotNull().NotEmpty().WithMessage("Günlük raporun hangi kursa ait olduğunu belirtmelisiniz..");
                RuleFor(r => r.Request.T_DersTarihi).NotNull().NotEmpty().WithMessage("Günlük raporun hangi güne ait olduğunu belirtmelisiniz..");
                RuleFor(r => r.Request.SinifAdi).NotNull().NotEmpty().WithMessage("Günlük raporun hangi sınıfa ait olduğunu belirtmelisiniz..");
            }
        }

        public static UT_KursGunlukRapor ToKursGunlukRapor(this Command command)
        {


            var kursGunlukRapor =  new UT_KursGunlukRapor
            {
                Id=command.Request.Id,
                KursId = command.Request.KursId,
                T_DersTarihi = command.Request.T_DersTarihi,
                SinifAdi = command.Request.SinifAdi,
                Aktifmi = true,
                T_Aktif=DateTime.Now,
                KursGunlukRaporDersler = command.Request.DerslerIds
                .Select(dersId => new UT_KursGunlukRaporDersler
                {
                    DersId = dersId,
                }).ToList()

            };
            return kursGunlukRapor;
            
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_KursGunlukRapors.Any(r=>r.Id == request.Request.Id);
                if (isExist) return await Result<bool>.FailAsync($"{request.Request.Id} is already exist");


                var kursGunlukRapor = request.ToKursGunlukRapor();
                Context.UT_KursGunlukRapors.Add(kursGunlukRapor);

                var isSaved = await Context.SaveChangesAsync() > 0;

                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} zamanında eklendi..", request.Request.Id, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);

                }
                return await Result<bool>.FailAsync("Kayıt başarılı değil");
            }
        }

    }

    public class CreateKursGunlukRaporEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/CreateKursGunlukRapor", async ([FromBody] KursGunlukRaporEkleRequest model, ISender sender) =>
            {
                var request = new CreateKursGunlukRapor.Command(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
