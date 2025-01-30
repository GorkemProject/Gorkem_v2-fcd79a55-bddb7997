
using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;

namespace Gorkem_.Features.KodTablo
{
    public static class CreateKursEgitimListesi
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Name { get; set; }
        }

        public class CreateKursEgitimListesiValidation : AbstractValidator<Command>
        {
            public CreateKursEgitimListesiValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "Eklenecek kursun adı boş olamaz..");
            }
        }

        public static KT_KursEgitimListesi ToKursEgitimListesi(this Command command)
        {
            return new KT_KursEgitimListesi
            {
                Name = command.Name,
                Aktifmi = true,
                T_Aktif = DateTime.Now,
            };
        }

        public sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {

                var isExist = Context.KT_KursEgitimListesis.Any(r => r.Name == request.Name);
                if (isExist) return await Result<bool>.FailAsync($"{request.Name} is already exist");

                Context.KT_KursEgitimListesis.Add(request.ToKursEgitimListesi());
                var isSaved = await Context.SaveChangesAsync() > 0;

                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} zamanında eklendi.", request.Name, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Kayıt başarılı değil");


                
            }
        }
    }
    public class CreateKursEgitimListesiEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           var mapGet= app.MapPost("kodtablo/CreateKursEgitimListesi", async ([FromBody] KursEgitimListesiEkleRequest model, ISender sender ) =>
            {
                var request = new CreateKursEgitimListesi.Command() { Name = model.KursAdi };

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
