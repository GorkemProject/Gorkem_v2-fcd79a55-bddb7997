using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Komisyon
{
    public static class DeleteKomisyon
    {
        public class Command: IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }

        public class DeleteKomisyonValidation : AbstractValidator<Command>
        {
            public DeleteKomisyonValidation()
            {
                RuleFor(r=>r.Id).GreaterThanOrEqualTo(0).Configure(r=>r.MessageBuilder =_=> "Id değeri boş olamaz");
            }
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentKomisyon = await Context.UT_Komisyons.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentKomisyon == null) return await Result<bool>.FailAsync($"with the {request.Id} data could is not found");
                currentKomisyon.Aktifmi = false;
                currentKomisyon.T_Pasif = DateTime.Now;

                var isDeleted = await Context.SaveChangesAsync()>0;

                if (isDeleted)
                {
                    Logger.Information($"{0} kaydı {1} tarafından {2} tarihinde silindi.", request.Id, "DemoUser", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Silme işlemi yapılamadı");
            }
        }
    }
    public class DeleteKomisyonEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("komisyon", async ([FromBody] KomisyonSilRequest model,ISender sender) =>
            {
                var request = new DeleteKomisyon.Command() {Id=model.Id };
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok($"With the {model.Id} id data has been deleted");
                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
