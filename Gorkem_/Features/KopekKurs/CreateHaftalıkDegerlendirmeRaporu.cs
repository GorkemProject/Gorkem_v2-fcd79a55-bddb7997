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
    public static class CreateHaftalıkDegerlendirmeRaporu
    {

        public record Command(HaftalıkDeferlendirmeRaporuEkleRequest Request) : IRequest<Result<bool>>;

        public class CreateHaftalıkDegerlendirmeRaporuValidation : AbstractValidator<Command>
        {
            public CreateHaftalıkDegerlendirmeRaporuValidation()
            {
                RuleFor(r => r.Request.KursId).NotEmpty().NotNull().WithMessage("KursId değeri boş geçilemez");
            }
        }
        public static UT_KursHaftalıkDegerlendirmeRaporu ToHaftalikDegerlendirmeRaporu(this Command command)
        {
            return new UT_KursHaftalıkDegerlendirmeRaporu
            {
                KursId = command.Request.KursId,
                Aktifmi = true,
                T_Aktif=DateTime.Now
            };
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_KursHaftalıkDegerlendirmeRaporus.Any(r => r.Id == request.Request.KursId);
                if (isExist) return await Result<bool>.FailAsync($"{request.Request.KursId} is already exist");

                Context.UT_KursHaftalıkDegerlendirmeRaporus.Add(request.ToHaftalikDegerlendirmeRaporu());

                var isSaved = await Context.SaveChangesAsync() > 0;

                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} tarihinde eklendi", request.Request.KursId, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Kayıt başarılı değil");

            }
        }
    }

    public class CreateHaftalikDegerlendirmeRaporuEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("KopekKurs/CreateHaftalikDegerlendirmeRaporu", async ([FromBody] HaftalıkDeferlendirmeRaporuEkleRequest model, ISender sender) =>
            {
                var request = new CreateHaftalıkDegerlendirmeRaporu.Command(model);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
