using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.KodTablo
{
    public static class CreateKursMufredat
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Name { get; set; }
            public int KursEgitimListesiId { get; set; }
        }

        public class CreateKursMufredatValidation : AbstractValidator<Command>
        {
            public CreateKursMufredatValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "Müfredat ismi boş olamaz");
                RuleFor(r => r.KursEgitimListesiId).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id Boş Olamaz.");

            }
        }

        public static KT_KursMufredat ToKursMufredat(this Command command)
        {
            return new KT_KursMufredat
            {
                Name = command.Name,
                KursEgitimListesiId = command.KursEgitimListesiId,
                Aktifmi = true,
                T_Aktif = DateTime.Now
            };

        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.KT_KursMufredats.Any(r=>r.Name ==request.Name);
                if (isExist) return await Result<bool>.FailAsync($"{request.Name} is already exist");

                Context.KT_KursMufredats.Add(request.ToKursMufredat());
                var isSaved = await Context.SaveChangesAsync()>0;

                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} Zamanında Eklendi", request.Name, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Kayıt Başarılı Değil");

            }
        }
    }

    public class CreateKursMufredatEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapPost("kodtablo/CreateKursMufredat", async ([FromBody] KursMufredatEkleRequest model, ISender sender) =>
            {
                var request = new CreateKursMufredat.Command() { Name=model.Name, KursEgitimListesiId=model.KursEgitimListesiId};

                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
