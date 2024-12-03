using System.Net.WebSockets;
using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class DeleteKurs
    {

        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }

        public class DeleteKursValidation : AbstractValidator<Command>
        {
            public DeleteKursValidation()
            {
                RuleFor(r => r.Id).NotNull().NotEmpty().Configure(r => r.MessageBuilder = _ => "Id değeri boş olamaz");
            }
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentKurs = await Context.UT_Kurs.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentKurs is null) return await Result<bool>.FailAsync($"{request.Id} değerindeki kursiyer bulunamadı..");

                currentKurs.Aktifmi = false;
                currentKurs.T_Pasif = DateTime.Now;

                var isDeleted = await Context.SaveChangesAsync() > 0;

                if (isDeleted)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} zamanında silindi", request.Id, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }

                return await Result<bool>.FailAsync("Silme işlemi yapılamadı..");
                
            }
        }

    }

    public class DeleteKursEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("kopekKurs/DeleteKurs", async ([FromBody] DeleteKursRequest model, ISender sender ) =>
            {
                var request = new DeleteKurs.Command() {Id=model.KursId };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);


            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
