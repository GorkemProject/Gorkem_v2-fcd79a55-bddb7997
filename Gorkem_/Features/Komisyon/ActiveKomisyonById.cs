using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Gorkem_.Features.Komisyon
{
    public static class ActiveKomisyonById
    {

        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }
        public class ActiveKomisyonByIdValidation : AbstractValidator<Command>
        {
            public ActiveKomisyonByIdValidation()
            {
                RuleFor(r=>r.Id).GreaterThanOrEqualTo(0).Configure(r=>r.MessageBuilder =_=> "Id değeri boş gönderilemez");
            }
        }

        internal sealed record Handler(GorkemDbContext context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var findKomisyon = await context.UT_Komisyons.FindAsync(request.Id);

                if (findKomisyon == null)
                {
                    return await Result<bool>.FailAsync("Komisyon bulunamadı");
                }
                if (findKomisyon.Aktifmi)
                {
                    return await Result<bool>.FailAsync("Bu komisyon zaten aktif");
                }

                findKomisyon.Aktifmi = true;
                findKomisyon.T_Aktif=DateTime.Now;
                findKomisyon.T_Pasif = null;
                

                context.UT_Komisyons.Update(findKomisyon);

                await context.SaveChangesAsync(cancellationToken);
                return await Result<bool>.SuccessAsync("Komisyon Aktif edildi");
            }
        }
    }
    public class ActiveKomisyonByIdEnpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("activekomisyon", async ([FromBody] KomisyonuAktifeAlRequest model, ISender sender) =>
            {
                var request =new ActiveKomisyonById.Command() { Id = model.Id };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);

                return Results.BadRequest(response);


            }).WithTags(EndpointConstants.KOMISYON);

        }
    }
}
