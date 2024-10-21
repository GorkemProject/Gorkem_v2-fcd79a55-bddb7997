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
    public static class RemoveUyeFromKomisyon
    {
        public record Command(KomisyondanUyeCikartRequest Request): IRequest<Result<bool>>;

        internal class Validate : AbstractValidator<Command>
        {
            public Validate()
            {
                RuleFor(r => r.Request.KomisyonUyeleriId).GreaterThan(0).WithMessage("Komisyondan çıkarılacak üyeyi seçmelisin");
                RuleFor(r => r.Request.KomisyonId).GreaterThan(0).WithMessage("Komisyonu seçmelisin");
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
                    .Include(k=>k.KomisyonUyeleri)
                    .FirstOrDefaultAsync(k=>k.Id == request.Request.KomisyonId);

                if (existingKomisyon == null)
                {
                    return await Result<bool>.FailAsync("Seçilen komisyon bulunamadı..");
                }
                var uye = existingKomisyon.KomisyonUyeleri?
                    .FirstOrDefault(u=>u.Id==request.Request.KomisyonUyeleriId);
                if (uye == null)
                {
                    return await Result<bool>.FailAsync("Seçilen üye komisyon içerisinde bulunamadı..");
                }
                existingKomisyon.KomisyonUyeleri?.Remove(uye);

                var isSaved = await context.SaveChangesAsync() > 0;

                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);

                return await Result<bool>.FailAsync("Komisyondan üye çıkarılamadı");
            }
        }
    }
    public class RemoveUyeFromKomisyonEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("komisyonuyecikar", async ([FromBody] KomisyondanUyeCikartRequest request, ISender sender) =>
            {
                var response = await sender.Send(new RemoveUyeFromKomisyon.Command(request));
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
