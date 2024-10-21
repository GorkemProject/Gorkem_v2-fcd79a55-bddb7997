using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using Gorkem_.Features.Idareci;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Gorkem_.Features.Komisyon
{
    public static class AddUyeToKomisyon
    {
        public record Command(KomisyonaUyeEkleRequest Request) : IRequest<Result<bool>>
        {

        }
        internal class Validate : AbstractValidator<Command>
        {
            public Validate()
            {
                RuleFor(r => r.Request.KomisyonUyeleriId).GreaterThan(0).WithMessage("Komisyon üyelerini seçmelisin");
                RuleFor(r => r.Request.KomisyonId).GreaterThan(0).WithMessage("Komisyon  seçmelisin");

            }
        }


        internal sealed class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly GorkemDbContext context;
            public Handler(GorkemDbContext context)
            {
                this.context = context;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var existingKomisyon = await context.UT_Komisyons
                    .Include(k => k.KomisyonUyeleri)
                    .FirstOrDefaultAsync(k => k.Id == request.Request.KomisyonId);

                if (existingKomisyon == null)
                {
                    return await Result<bool>.FailAsync("Seçilen komisyon bulunamadı");
                }
                var uye = await context.UT_KomisyonUyeleris
                    .FirstOrDefaultAsync(u => u.Id == request.Request.KomisyonUyeleriId);

                if (uye == null)
                {
                    return await Result<bool>.FailAsync("Seçilen üye bulunamadı.");
                }

                existingKomisyon.KomisyonUyeleri?.Add(uye);

                var isSaved = await context.SaveChangesAsync() > 0;

                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);

                return await Result<bool>.FailAsync("Komisyona üye eklenemedi.");
            }
        }
    }
    public class AddUyeToKomisyonEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("komisyonkomisyonuye", async ([FromBody] KomisyonaUyeEkleRequest request, ISender sender) =>
            {
                var response = await sender.Send(new AddUyeToKomisyon.Command(request));
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOMISYON);
        }
    }

}
