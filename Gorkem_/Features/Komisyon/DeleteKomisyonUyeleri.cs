using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using Gorkem_.Features.Kopek;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Komisyon
{
    public static class DeleteKomisyonUyeleri
    {
        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }
        public class DeleteKomisyonUyeleriValidation : AbstractValidator<Command>
        {
            public DeleteKomisyonUyeleriValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id boş olamaz");

            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentKomisyonUye = await Context.UT_KomisyonUyeleris.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentKomisyonUye is null) return await Result<bool>.FailAsync($"with the {request.Id} Id data could not found!");

                currentKomisyonUye.Aktifmi = false;
                currentKomisyonUye.T_Pasif=DateTime.Now;
                var isDeleted = await Context.SaveChangesAsync()>0;

                if (isDeleted)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} zamanında silindi", request.Id, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Silme işlemi yapılamadı");
            }
        }
    }
    public class DeleteKomisyonUyeleriEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("komisyonuyeleri", async ([FromBody] KomisyonUyesiSilRequest model, ISender sender ) =>
            {
                var request = new DeleteKomisyonUyeleri.Command() { Id = model.Id };
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
