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
                RuleFor(r => r.Request.Puan).NotEmpty().WithMessage("Puan boş bırakılamaz.");
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
                var isExist = await Context.UT_SecimTestiCevaplar
                    .AnyAsync(r => r.UtSecimTestId == request.Request.UtSecimTestId && r.SoruId == request.Request.SoruId, cancellationToken);
                if (isExist)
                    return await Result<bool>.FailAsync("Bu cevap zaten mevcut");

                Context.UT_SecimTestiCevaplar.Add(request.ToSecimTestiCevap());

                var isSaved = await Context.SaveChangesAsync() > 0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} tarihinde eklendi", request.Request.Puan, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Kayıt Başarılı değil");
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
