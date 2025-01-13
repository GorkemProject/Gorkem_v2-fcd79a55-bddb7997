using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                AdayIdareciId=model.IdareciId,
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
                var idareci = await context.UT_AdayIdareci.FirstOrDefaultAsync(x=>x.Id.Equals(request.Request.IdareciId));
                if(idareci is null) return await Result<bool>.FailAsync("Idareci Bulunamadı!!");
                request.Request.IdareciId = idareci.Id;
                context.UT_IdareciKopekleri.Add(request.Request.toIdareciKopekleri());
                try
                {
                    var isDataSaved = await context.SaveChangesAsync()>0;
                    if (isDataSaved) return await Result<bool>.SuccessAsync(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ana Hata: {ex.Message}");
                    Console.WriteLine($"İç Hata: {ex.InnerException?.Message}");
                    Console.WriteLine($"Stack Trace: {ex.InnerException?.StackTrace}");
                    return await Result<bool>.FailAsync("Idareciye Kopek Eklenemedi!!");
                }
                

                
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
