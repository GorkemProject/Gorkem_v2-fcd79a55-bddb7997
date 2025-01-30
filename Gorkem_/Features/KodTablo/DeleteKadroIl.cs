using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Gorkem_.Features.KodTablo
{
    public static class DeleteKadroIl
    {
        public class Command : IRequest<Result<bool>> { public int Id { get; set; } }


        public class DeleteKadroIlValidation : AbstractValidator<Command>
        {

            public DeleteKadroIlValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id Boş Olamaz.");
            }
        }



        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {

             

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentKadroIl = await Context.KT_KadroIls.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentKadroIl is null) return await Result<bool>.FailAsync($"With the {request.Id}  Id data could not found!");

                currentKadroIl.Aktifmi = false;
                currentKadroIl.T_Pasif = DateTime.Now;
                var isDeleted = await Context.SaveChangesAsync() > 0;

                if (isDeleted)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Silme İşlemi Yapılamadı.");
            }
        }


    }
    public class DeleteKadroIlEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           var mapGet= app.MapDelete("kodtablo/kadroil", async ([FromBody] KadroIlSilRequest model, ISender sender) =>
            {
                var request = new DeleteKadroIl.Command() { Id = model.Id };
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
