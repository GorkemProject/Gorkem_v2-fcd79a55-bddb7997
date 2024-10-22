using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.Idareci
{
    public static class AddKopekToIdareci
    {
        public record Command(IdareciyeKopekEkleRequest Request) : IRequest<Result<bool>> { }

        internal class Validate : AbstractValidator<Command>
        {
            public Validate()
            {
                RuleFor(r => r.Request.IdareciId).GreaterThan(0).WithMessage("İdareci Seçmelisiniz.");
                RuleFor(r => r.Request.KopekId).GreaterThan(0).WithMessage("Köpek Seçmelisiniz.");
            }

        }
        internal static UT_IdareciKopekleri toIdareciKopekleri(this IdareciyeKopekEkleRequest model)
        {
            return new UT_IdareciKopekleri
            {
                Aktifmi=true,
                IdareciId=model.IdareciId,
                KopekId=model.KopekId,
                T_Aktif=DateTime.UtcNow
            };

        }

        internal sealed class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly GorkemDbContext context;
            public Handler(GorkemDbContext context)
            {
                this.context=context;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                this.context.UT_IdareciKopekleri.Add(request.Request.toIdareciKopekleri());
                var isDataSaved = await this.context.SaveChangesAsync()>0;

                if (isDataSaved) return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Idareciye Kopek Eklenemedi!!");
            }
        }
    }
    public class AddKopekToIdareciEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("idareci/addKopekToIdareci", async ([FromBody] IdareciyeKopekEkleRequest request, ISender sender) =>
            {
                var response = await sender.Send(new AddKopekToIdareci.Command(request));

                if (response.Succeeded)
                    return Results.Ok(response);

                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.IDARECI);
        }
    }
}
