using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using FluentValidation.AspNetCore;
using Gorkem_.Context;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using Gorkem_.Enums;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Gorkem_.Features.Komisyon
{
    public static class DeactiveKomisyonById
    {
        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }
        }

        public class DeactiveKomisyonByIdValidation : AbstractValidator<Command>
        {
            public DeactiveKomisyonByIdValidation()
            {
                RuleFor(r=>r.Id).GreaterThanOrEqualTo(0).Configure(r=>r.MessageBuilder =_=> "Id değeri boş gönderilemez..");
            }
        }

        internal sealed record Handler(GorkemDbContext context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var findKomisyon = await context.UT_Komisyons.FindAsync(request.Id);

                if (findKomisyon == null)
                {
                    return await Result<bool>.FailAsync("Komisyon bulunamadı..");
                }
                if (!findKomisyon.Aktifmi)
                {
                    return await Result<bool>.FailAsync("Bu komisyon zaten pasif");
                }

                findKomisyon.Aktifmi = false;
                findKomisyon.T_Pasif = DateTime.Now;

                context.UT_Komisyons.Update(findKomisyon);

                await context.SaveChangesAsync(cancellationToken);
                return await Result<bool>.SuccessAsync("Komisyon pasife çekildi.");
            }
        }
    }
    public class DeactiveKomisyonByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           var mapGet= app.MapPost("komisyon/deactiveKomisyon", async ([FromBody] KomisyonuPasifeAlRequest model, ISender sender ) =>
            {
                var request = new DeactiveKomisyonById.Command() { Id = model.Id };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
                
                
            }).WithTags(EndpointConstants.KOMISYON);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
