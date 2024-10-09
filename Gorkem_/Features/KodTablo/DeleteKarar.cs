using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class DeleteKarar
    {
        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }

        public class DeleteKararValidation : AbstractValidator<Command>
        {
            public DeleteKararValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id değeri boş olamaz");

            }
        }

        public sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentKarar = await Context.KT_Karars.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentKarar is null) return await Result<bool>.FailAsync($"{request.Id} Id data could not found!");

                currentKarar.Aktifmi = false;
                currentKarar.T_Pasif =DateTime.Now;

                var isDeleted = await Context.SaveChangesAsync() > 0 ;

                if(isDeleted)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Silme işlemi yapılamadı");

            }
        }
    }
    public class DeleteKararEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("kodtablo/karar", async ([FromBody] KararSilRequest model, ISender sender) =>
            {
                var request = new DeleteKarar.Command() { Id = model.Id };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
