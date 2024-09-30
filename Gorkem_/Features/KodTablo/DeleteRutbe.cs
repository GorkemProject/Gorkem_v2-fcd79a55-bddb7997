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
    public static class DeleteRutbe
    {
        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }
        public class DeleteRutbeValidation : AbstractValidator<Command>
        {
            public DeleteRutbeValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id Değeri Boş Olamaz.");
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
 
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentRutbe = await Context.KT_Rutbes.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentRutbe is null) return await Result<bool>.FailAsync($"With the {request.Id} Id data could not found!");

                currentRutbe.Aktifmi = false;
                currentRutbe.T_Pasif = DateTime.Now;
                var isDeleted = await Context.SaveChangesAsync() > 0;

                if (isDeleted)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Silme İşlemi Yapılamadı.");
                {

                }
            }
        }
    }
    public class DeleteRutbeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("kodtablo/rutbe", async ([FromBody] RutbeSilRequest model, ISender sender) =>
            {
                var request = new DeleteRutbe.Command() { Id = model.Id };
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
