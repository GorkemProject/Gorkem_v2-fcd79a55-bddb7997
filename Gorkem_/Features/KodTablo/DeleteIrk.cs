using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class DeleteIrk
    {
        public class Command : IRequest<Result<bool>> { public int Id { get; set; } }
        public class DeleteIrkValidation : AbstractValidator<Command>
        {
            public DeleteIrkValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id Boş Olamaz");
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
 

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentBirim = await Context.KT_Irks.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentBirim is null) return await Result<bool>.FailAsync($"With the {request.Id} Id data could not found!");

                currentBirim.Aktifmi = false;
                currentBirim.T_Pasif = DateTime.Now;
                var isDeleted = await Context.SaveChangesAsync() > 0;
                if (isDeleted)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Silme İşlemi Yapılamadı.");
            }
        }
    }
    public class DeleteIrkEndpoint : ICarterModule
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("kodtablo/irk", async ([FromBody] IrkSilRequest model, ISender sender) =>
            {
                var request = new DeleteIrk.Command() { Id = model.Id };
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
