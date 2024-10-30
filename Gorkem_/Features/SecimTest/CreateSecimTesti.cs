using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.SecimTest;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.SecimTest
{
    public static class CreateSecimTesti
    {
        public record Command (SecimTestiEkleRequest Request) : IRequest<Result<bool>>
        {

        }
        public class CreateSecimTestiValidation : AbstractValidator<Command>
        {
            public CreateSecimTestiValidation()
            {
                RuleFor(r => r.Request.KopekId).NotEmpty().NotNull().WithMessage("Kopek Id boş bırakılamaz");
                RuleFor(r => r.Request.IdareciId).NotEmpty().NotNull().WithMessage("Idareci Id boş bırakılamaz");
                RuleFor(r => r.Request.SecimTestId).NotEmpty().NotNull().WithMessage("Seçim Testi Id boş bırakılamaz");
                RuleFor(r => r.Request.ToplamPuan).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100).WithMessage("Toplam puan 0 ile 100 arasında olmalıdır..");

            }
        }


        public static UT_SecimTest ToSecimTesti(this Command command)
        {
            return new UT_SecimTest
            {
                Id=command.Request.Id,
                T_Aktif=DateTime.Now,
                Aktifmi = true,
                KopekId = command.Request.KopekId,
                IdareciId = command.Request.IdareciId,
                SecimTestId = command.Request.SecimTestId,
                SinavYeriId = command.Request.SinavYeriId,
                Tarih = command.Request.Tarih,
                TepkiSekli = command.Request.TepkiSekli,
                Havlama = command.Request.Havlama,
                SecimTestBrans = command.Request.SecimTestBrans,
                Degerlendirme = command.Request.Degerlendirme,
                TestKomisyonu = command.Request.TestKomisyonu,
                ToplamPuan = command.Request.ToplamPuan
            };
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_SecimTests.Any(r => r.Id == request.Request.Id);
                if (isExist) return await Result<bool>.FailAsync($"{request.Request.Id} numaralı test zaten var..");


                Context.UT_SecimTests.Add(request.ToSecimTesti());

                var isSaved = await Context.SaveChangesAsync() > 0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} tarihinde eklendi..", request.Request.Id, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Kayıt başarılı değil");

            }
        }
    }

    public class CreateSecimTestiEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("secimTesti/CreateSecimTesti", async ([FromBody] SecimTestiEkleRequest model, ISender sender) =>
            {
                var request = new CreateSecimTesti.Command(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.SECİMTEST);
        }
    }
}
