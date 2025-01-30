using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Kopek;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;

namespace Gorkem_.Features.Kopek
{
    public static class DeleteKopek
    {
        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }
        public class DeleteKopekValidation : AbstractValidator<Command>
        {
            public DeleteKopekValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id Boş Olamaz.");
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {


            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentKopek = await Context.UT_Kopek_Kopeks.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentKopek is null) return await Result<bool>.FailAsync($"with the {request.Id}  Id data could not found!");

                currentKopek.Aktifmi = false;
                currentKopek.T_Pasif = DateTime.Now;
                var isDeleted = await Context.SaveChangesAsync() > 0;

                if (isDeleted)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} Zamanında Silindi", request.Id, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Silme işlemi yapılamadı.");

            }
        }
    }
    public class DeleteKopekEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapDelete("kopek/deleteKopek", async ([FromBody] KopekSilRequest model, ISender sender) =>
             {
                 var request = new DeleteKopek.Command() { Id = model.Id };
                 var response = await sender.Send(request);
                 if (response.Succeeded)
                     return Results.Ok($"With the {model.Id} id data has been deleted");
                 return Results.BadRequest(response.Message);
             }).WithTags(EndpointConstants.KOPEK);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
