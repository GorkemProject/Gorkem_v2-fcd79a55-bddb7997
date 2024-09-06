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
    public static class DeleteKopekDurum
    {
        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }

        }
        public class DeleteKopekDurumValidation : AbstractValidator<Command>
        {

            public DeleteKopekDurumValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id Boş Olamaz.");
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
 
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentKopekDurum = await Context.KT_KopekDurumus.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentKopekDurum is null) return await Result<bool>.FailAsync($"With the {request.Id} Id data could not found");

                currentKopekDurum.Aktifmi = false;
                currentKopekDurum.T_Pasif=DateTime.Now;
                var isDeleted = await Context.SaveChangesAsync() > 0;

                if (isDeleted)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("silme işlemi yapılamadı");
               
            }
        }
    }
    public class DeleteKopekDurumEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("kodtablo/kopekdurum", async ([FromBody] KopekDurumSilRequest model, ISender sender) =>
            {
                var request = new DeleteKopekDurum.Command() { Id = model.Id };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok($"with the {model.Id} id data has been deleted");
                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
