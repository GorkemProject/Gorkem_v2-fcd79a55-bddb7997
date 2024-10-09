using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Gorkem_.Features.KodTablo
{
    public static class CreateKarar
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Name { get; set; }
        }

        public class CreateKararValidation : AbstractValidator<Command>
        {
            public CreateKararValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "Karar bölümü boş olamaz.");

            }
        }
        public static KT_Karar ToKarar(this Command command)
        {
            return new KT_Karar
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
                var isExist = Context.KT_Karars.Any(r => r.Name == request.Name);
                if (isExist) return await Result<bool>.FailAsync($"{request.Name} is already exist");

                Context.KT_Karars.Add(request.ToKarar());
                var isSaved = await Context.SaveChangesAsync() > 0;

                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} Zamanında Eklendi", request.Name, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Kayıt işlemi başarılı değil.");

            }
        }
    }
    public class CreateKararEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kodtablo/karar", async ([FromBody] KararEkleRequest model, ISender sender) =>
            {
                var request = new CreateKarar.Command() { Name = model.KararAdi };
                var response = await sender.Send(request);
                if (response.Succeeded)
                     return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
