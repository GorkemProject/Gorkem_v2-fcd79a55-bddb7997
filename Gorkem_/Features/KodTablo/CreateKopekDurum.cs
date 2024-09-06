using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.KodTablo
{
    public static class CreateKopekDurum
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Name { get; set; }
        }
        public class CreateKopekDurumValidation : AbstractValidator<Command>
        {
            public CreateKopekDurumValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "Ad Boş Olamaz");
            }
        }
        public static KT_KopekDurumu ToKopekDurum(this Command command)
        {
            return new KT_KopekDurumu
            {
                Name = command.Name,
                //Kayıt Esnasında aktiflik durumu false olarak geldiği için bu kısmı ekledim. Aktifleştirilme Tarihini de ekledim.
                Aktifmi = true,
                T_Aktif = DateTime.Now

            };
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
           
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.KT_KopekDurumus.Any(r => r.Name == request.Name);
                if (isExist) return await Result<bool>.FailAsync($"{request.Name} is already exists");

                Context.KT_KopekDurumus.Add(request.ToKopekDurum());
                var isSaved = await Context.SaveChangesAsync()>0;

                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);

                return await Result<bool>.FailAsync("Kayıt Başarılı Değil");

            }
        }
    }
    public class CreateKopekDurumEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kodtablo/kopekdurum", async ([FromBody] KopekDurumEkleRequest model, ISender sender) =>
            {
                var request = new CreateKopekDurum.Command() { Name = model.KopekDurum };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok();
                return Results.BadRequest(response.Message);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
