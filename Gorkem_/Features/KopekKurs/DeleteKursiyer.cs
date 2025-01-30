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
    public static class DeleteKursiyer
    {

        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }
        public class DeleteKursiyerValidation : AbstractValidator<Command>
        {
            public DeleteKursiyerValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id değeri boş olamaz");
            }
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentKursiyer = await Context.UT_Kursiyer.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentKursiyer is null) return await Result<bool>.FailAsync($"{request.Id} değerindeki kursiyer bulunamadı..");

                currentKursiyer.Aktifmi = false;
                currentKursiyer.T_Pasif = DateTime.Now;

                var isDeleted = await Context.SaveChangesAsync() > 0;

                if (isDeleted)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} zamanında silindi", request.Id, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }

                return await Result<bool>.FailAsync("Silme işlemi yapılamadı");

            }
        }
    }

    public class DeleteKursiyerEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapDelete("kopekKurs/DeleteKursiyer", async ([FromBody] DeleteKursiyerRequest model, ISender sender) =>
             {
                 var request = new DeleteKursiyer.Command() { Id = model.Id };
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
