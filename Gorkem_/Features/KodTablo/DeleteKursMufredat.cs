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
    public static class DeleteKursMufredat
    {
        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }

        public class DeleteKursMufredatValidation : AbstractValidator<Command>
        {
            public DeleteKursMufredatValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id Boş Olamaz");
            }
        }

        public sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentMufredat = await Context.KT_KursMufredats.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentMufredat is null) return await Result<bool>.FailAsync($"{request.Id} Id data could not found!");

                currentMufredat.Aktifmi = false;
                currentMufredat.T_Pasif = DateTime.Now;

                var isDeleted = await Context.SaveChangesAsync() > 0;
                if (isDeleted)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Silme işlemi yapılamadı");

            }
        }
    }
    public class DeleteKursMufredatEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           var mapGet= app.MapDelete("kodtablo/DeleteKursMufredat", async ([FromBody] KursMufredatSilRequest model, ISender sender) =>
            {
                var request = new DeleteKursMufredat.Command() { Id = model.Id };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);



            }).WithTags(EndpointConstants.KODTABLO);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
 