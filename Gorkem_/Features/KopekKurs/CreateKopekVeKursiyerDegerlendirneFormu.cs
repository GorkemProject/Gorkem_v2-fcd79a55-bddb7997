using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using Gorkem_.Migrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.KopekKurs
{
    public static class CreateKopekVeKursiyerDegerlendirneFormu
    {

        public record Command(KopekVeKursiyerDegerlendirmeFormuRequest Request) : IRequest<Result<int>>;

        public class CreateKopekVeKursiyerDegerlendirmeFormuValidation : AbstractValidator<Command>
        {
            public CreateKopekVeKursiyerDegerlendirmeFormuValidation()
            {
                RuleFor(r => r.Request.KursId).NotEmpty().NotNull().WithMessage("Hangi kursa dair değerlendirme yaptığınızı belirtmelisiniz");
                RuleFor(r => r.Request.TestinYapildigiIlId).NotEmpty().NotNull().WithMessage("Testin hangi ilde yapıldığını belirtmelisiniz");
                RuleFor(r => r.Request.TestinYapildigiYer).NotEmpty().NotNull().WithMessage("Testin nerede yapıldığını belirtmelisiniz");
                RuleFor(r => r.Request.TarihSaat).NotEmpty().NotNull().WithMessage("Testin tarihte yapıldığını belirtmelisiniz");


            }
        }

        public static UT_KopekVeIdareciDegerlendirmeFormu ToKopekVeIdareciDegerlendirmeFormu(this Command command)
        {
            return new UT_KopekVeIdareciDegerlendirmeFormu
            {
                Aktifmi=true,
                T_Aktif=DateTime.Now,
                KursId=command.Request.KursId,
                TarihSaat=command.Request.TarihSaat,
                TestinYapildigiIlId = command.Request.TestinYapildigiIlId,
                TestinYapildigiYer = command.Request.TestinYapildigiYer,
 

            };
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<int>>
        {
            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_KopekVeIdareciDegerlendirmeFormu.Any(r => r.Id == request.Request.Id);
                if (isExist) return await Result<int>.FailAsync($"{request.Request.Id} numaralı değerlendirme formu zaten var");

                Context.UT_KopekVeIdareciDegerlendirmeFormu.Add(request.ToKopekVeIdareciDegerlendirmeFormu());
                var isSaved = await Context.SaveChangesAsync() > 0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} tarihinde eklendi..", request.Request.Id, "DemoAccount", DateTime.Now);
                    return await Result<int>.SuccessAsync(request.Request.Id);
                }
                return await Result<int>.FailAsync("kayıt başarılı değil");
            }
        }
    }
    public class CreateKopekVeKursiyerDegerlendirneFormuEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/CreateKopekVeKursiyerDegerlendirneFormu", async ([FromBody] KopekVeKursiyerDegerlendirmeFormuRequest model, ISender sender) =>
            {
                var request = new CreateKopekVeKursiyerDegerlendirneFormu.Command(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);


            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }

}
