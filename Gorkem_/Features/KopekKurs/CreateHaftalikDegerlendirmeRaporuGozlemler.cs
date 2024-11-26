using System.ComponentModel.Design;
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
    public static class CreateHaftalikDegerlendirmeRaporuGozlemler
    { 
        public record Command(HaftalikDegerlendirmeRaporuGozlemEkleRequest Request) : IRequest<Result<bool>>;

        public class CreateHaftalikDegerlendirmeRaporuGozlemlerValidation : AbstractValidator<Command>
        {
            public CreateHaftalikDegerlendirmeRaporuGozlemlerValidation()
            {
                RuleFor(r => r.Request.KursiyerId).NotEmpty().NotNull().WithMessage("Kursiyer boş bıraklamaz..");
                RuleFor(r => r.Request.Gozlem).NotEmpty().NotNull().WithMessage("Gözlem boş bıraklamaz..");
            }
        }

        public static UT_HaftalıkDegerlendirmeRaporuGozlemler ToHaftalikDegerlendirmeRaporuGozlemler(this Command command)
        {
            return new UT_HaftalıkDegerlendirmeRaporuGozlemler
            {
                Aktifmi = true,
                Gozlemler = command.Request.Gozlem,
                KursiyerId = command.Request.KursiyerId,
                T_Aktif = DateTime.Now
                

            };

        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_HaftalıkDegerlendirmeRaporuGozlemlers.Any(r => r.Id == request.Request.KursiyerId);
                if (isExist) return await Result<bool>.FailAsync($"{request.Request.KursiyerId} is already exist");

                Context.UT_HaftalıkDegerlendirmeRaporuGozlemlers.Add(request.ToHaftalikDegerlendirmeRaporuGozlemler());

                var isSaved = await Context.SaveChangesAsync() > 0;

                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} tarihinde eklendi", request.Request.KursiyerId, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Kayıt başarılı değil");

            }
        }
    }
    public class CreateHaftalikDegerlendirmeRaporuGozlemEndpoint : ICarterModule
    {
        public async void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/CreateHaftalikDegerlendirmeRaporuGozlem", async ([FromBody] HaftalikDegerlendirmeRaporuGozlemEkleRequest model, ISender sender) =>
            {
                var request = new CreateHaftalikDegerlendirmeRaporuGozlemler.Command(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
