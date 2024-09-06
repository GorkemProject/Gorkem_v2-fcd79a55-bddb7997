using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Gorkem_.Features.KodTablo
{
    public static class CreateAskerlik
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Name { get; set; }

        }
        public class CreateAskerlikValidation : AbstractValidator<Command>
        {
            public CreateAskerlikValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "Askerlik durum adı boş olamaz.");
            }
        }
        public static KT_Askerlik ToAskerlik(this Command command)
        {
            return new KT_Askerlik
            {
                Name = command.Name,
                Aktifmi = true,
                T_Aktif = DateTime.Now,
            };
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        { 
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.KT_Askerliks.Any(r => r.Name == request.Name);
                if (isExist) return await Result<bool>.FailAsync($"{request.Name} is already exists");

                Context.KT_Askerliks.Add(request.ToAskerlik());
                var isSaved = await Context.SaveChangesAsync() > 0;

                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} Zamanında Eklendi", request.Name, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }


                return await Result<bool>.FailAsync("Kayıt Başarılı Değil");

            }
        }
    }
    public class CreateAskerlikValidation : ICarterModule
    {
        public async void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kodtablo/askerlik", async ([FromBody] AskerlikEkleRequest model, ISender sender) =>
            {
                var request = new CreateAskerlik.Command() { Name = model.AskerlikDurumAdi };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok();
                return Results.BadRequest(response.Message);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
