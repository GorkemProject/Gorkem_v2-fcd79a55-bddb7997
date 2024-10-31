using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.SecimTest;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Gorkem_.Features.SecimTest
{
    public static class CreateSecimTestiCevap
    {

        public record Command(SecimTestiCevapEkleRequest Request) : IRequest<Result<bool>>;

        public class CreateSecimTestiCevapValidation : AbstractValidator<Command>
        {
            public CreateSecimTestiCevapValidation()
            {
                RuleFor(r => r.Request.UtSecimTestId).NotEmpty().WithMessage("Seçim Testi ID boş bırakılamaz.");
                RuleFor(r => r.Request.SoruId).NotEmpty().WithMessage("Soru ID boş bırakılamaz.");
                RuleFor(r => r.Request.Puan).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100).WithMessage("Toplam puan 0 ile 100 arasında olmalıdır..");
            }
        }

        public static UT_SecimTestiCevap ToSecimTestiCevap(this Command command)
        {
            return new UT_SecimTestiCevap
            {
                
                Aktifmi = true,
                T_Aktif = DateTime.Now,
                UtSecimTestId = command.Request.UtSecimTestId,
                SoruId = command.Request.SoruId,
                Puan = command.Request.Puan,
            };

        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var secimTest = await Context.UT_SecimTests
                     .Where(t => t.Id == request.Request.UtSecimTestId)
                     .Select(t => t.SecimTestId)
                     .FirstOrDefaultAsync(cancellationToken);

                if (secimTest == null)
                    return await Result<bool>.FailAsync("Seçilen Seçim Testi Bulunamadı");

                var soru = await Context.KT_Sorus
                    .Where(s=>s.Id == request.Request.SoruId && s.SecimTestId == secimTest)
                    .FirstOrDefaultAsync(cancellationToken);

                if (soru == null)
                {
                    return await Result<bool>.FailAsync("Seçilen soru ilgili seçime ait değil");
                }

                if (request.Request.Puan > soru.Puan)
                {
                    return await Result<bool>.FailAsync($" Girilen puan, maksimum {soru.Puan} puanından yüksek olamaz.");
                }

                var secimTestiCevap = new UT_SecimTestiCevap
                {
                    T_Aktif = DateTime.Now,
                    Aktifmi=true,
                    UtSecimTestId = request.Request.UtSecimTestId,
                    SoruId = request.Request.SoruId,
                    Puan = request.Request.Puan,
                };

                Context.UT_SecimTestiCevaplar.Add(secimTestiCevap);
                var isSaved = await Context.SaveChangesAsync() > 0;

                if (isSaved)
                {
                    Logger.Information("Secim Testi Cevabı eklendi: SecimTestId={0}, SoruId={1}, Puan={2}", request.Request.UtSecimTestId, request.Request.SoruId, request.Request.Puan);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Cevap kaydı başarısız.");

            }
        }
    }
    public class CreateSecimTestiCevapEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("secimTesti/CreateSecimTestiCevap", async ([FromBody] SecimTestiCevapEkleRequest model, ISender sender) =>
            {
                var request = new CreateSecimTestiCevap.Command(model);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.SECİMTEST);
        }
    }
}
