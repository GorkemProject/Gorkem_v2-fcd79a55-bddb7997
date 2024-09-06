using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;


namespace Gorkem_.Features.KodTablo
{
    public static class CreateIdareciDurum
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Name { get; set; }
        }
        public class CreateDurumValidation : AbstractValidator<Command>
        {
            public CreateDurumValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "Ad Boş Olamaz");
            }
        }
        public static KT_IdareciDurum ToIdareciDurum(this Command command)
        {
            return new KT_IdareciDurum
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
                var isExist = Context.KT_IdareciDurum.Any(r => r.Name == request.Name);
                if (isExist) return await Result<bool>.FailAsync($"{request.Name} is already exists");

                Context.KT_IdareciDurum.Add(request.ToIdareciDurum());
                var isSaved = await Context.SaveChangesAsync() > 0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Kayıt işlemi başarılı değil.");
            }
        }
    }
    public class CreateDurumEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kodtablo/idarecidurum", async ([FromBody] IdareciDurumEkleRequest model, ISender sender) =>
            {
                var request = new CreateIdareciDurum.Command() { Name = model.DurumAdi };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok();
                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
