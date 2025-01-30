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
    public static class DeleteKursEgitmen
    {
        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }
        public class DeleteKursEgitmenValidation : AbstractValidator<Command>
        {
            public DeleteKursEgitmenValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id boş olmaz");
            }
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentKursEgitmen = await Context.UT_KursEgitmenler.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentKursEgitmen is null) return await Result<bool>.FailAsync($"with the {request.Id} Id data could not found");

                currentKursEgitmen.Aktifmi = false;
                currentKursEgitmen.T_Pasif = DateTime.Now;
                var isDeleded = await Context.SaveChangesAsync() > 0;

                if (isDeleded)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} zamanında silindi", request.Id, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Silme işlemi yapılamadı");

            }
        }
    }

    public class DeleteKursEgitmenEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapDelete("kopekKurs/DeleteKursEgitmen", async ([FromBody] KursEgitmenSilRequest model, ISender sender) =>
              {
                  var request = new DeleteKursEgitmen.Command() { Id = model.Id };
                  var response = await sender.Send(request);

                  if (response.Succeeded)
                      return Results.Ok(response);
                  return Results.BadRequest(response);

              }).WithTags(EndpointConstants.KOPEKKURS);
            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
