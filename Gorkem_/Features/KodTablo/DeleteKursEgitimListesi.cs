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
    public static class DeleteKursEgitimListesi
    {
        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }
        public class DeleteKursEgitimListesiValidation : AbstractValidator<Command>
        {
            public DeleteKursEgitimListesiValidation()
            {
                RuleFor(r=>r.Id).GreaterThanOrEqualTo(0).Configure(r=>r.MessageBuilder =_=> "Id değeri boş olamaz");
            }
        }

        public sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentKursEgitim = await Context.KT_KursEgitimListesis.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentKursEgitim is null) return await Result<bool>.FailAsync($"{request.Id} Id data could not found!");

                currentKursEgitim.Aktifmi = false;
                currentKursEgitim.T_Pasif = DateTime.Now;

                var isDeleted = await Context.SaveChangesAsync()>0;
                if (isDeleted)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Silme işlemi yapılmadı");
            }
        }
    }

    public class DeleteKursEgitimListesiEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("kodtablo/DeleteKursEgitimListesi", async ([FromBody] KursEgitimListesiSilRequest model, ISender sender) =>
            {
                var request = new DeleteKursEgitimListesi.Command() { Id=model.Id };

                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);



            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
