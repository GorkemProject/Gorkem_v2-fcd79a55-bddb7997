using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Gorkem_.Features.KodTablo
{
    public static class DeleteBirim
    {
        public class Command : IRequest<Result<bool>> { public int Id { get; set; } }


        public class DeleteBirimValidation : AbstractValidator<Command>
        {

            public DeleteBirimValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id Boş Olamaz.");
            }
        }



        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {

             

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentBirim = await Context.KT_Birims.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentBirim is null) return await Result<bool>.FailAsync($"With the {request.Id}  Id data could not found!");

                currentBirim.Aktifmi = false;
                currentBirim.T_Pasif = DateTime.Now;
                var isDeleted = await Context.SaveChangesAsync() > 0;

                if (isDeleted)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Silme İşlemi Yapılamadı.");
            }
        }


    }
    public class DeleteBirimEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("kodtablo/birim", async ([FromBody] BirimSilRequest model, ISender sender) =>
            {
                var request = new DeleteBirim.Command() { Id = model.Id };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok($"With the {model.Id} id data has been deleted");
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
