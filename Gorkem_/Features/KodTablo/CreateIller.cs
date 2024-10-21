using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace Gorkem_.Features.KodTablo
{
    public static class CreateIller
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Name { get; set; }
        }
        public class CreateIllerValidation : AbstractValidator<Command>
        {
            public CreateIllerValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "İllerin Adı Boş olamaz");
            }
        }
        public static KT_GorevYeri ToIller(this Command command)
        {
            return new KT_GorevYeri
            {
                Name = command.Name,
                Aktifmi = true,
                T_Aktif = DateTime.Now
            };
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.KT_GorevYeris.Any(r => r.Name == request.Name);
                if (isExist) return await Result<bool>.FailAsync($"{request.Name} is already exists");

                Context.KT_GorevYeris.Add(request.ToIller());

                var isSaved = await Context.SaveChangesAsync()>0;

                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} Zamanında Eklendi", request.Name, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }

                return await Result<bool>.FailAsync("Kayıt başarılı değil");
            }
        }
    }
    public class CreateIllerValidation : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kodtablo/iller", async ([FromBody] IllerEkleRequest model, ISender sender) =>
            {
                var request = new CreateIller.Command() { Name = model.IlAdi };
                var response = await sender.Send(request);

                if(response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
