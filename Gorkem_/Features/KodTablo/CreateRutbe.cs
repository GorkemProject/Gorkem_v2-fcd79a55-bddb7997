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
    public static class CreateRutbe
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Name { get; set; }
        }
        public class CreateRutbeValidation : AbstractValidator<Command>
        {
            public CreateRutbeValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "Rütbe ismi boş olamaz.");
            }
        }
        public static KT_Rutbe ToRutbe(this Command command)
        {
            return new KT_Rutbe
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
                var isExists = Context.KT_Rutbes.Any(r => r.Name == request.Name);
                if (isExists) return await Result<bool>.FailAsync($"{request.Name} is already exists");

                Context.KT_Rutbes.Add(request.ToRutbe());
                
                var isSaved = await Context.SaveChangesAsync(cancellationToken)>0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Kayıt başarılı değil");
            }
        }
    }
    public class CreateRutbeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kodtablo/rutbe", async ([FromBody] RutbeEkleRequest model, ISender sender) =>
            {
                var request = new CreateRutbe.Command() { Name = model.RutbeAdi };
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
