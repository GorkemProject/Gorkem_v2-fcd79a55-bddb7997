using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.SecimTest;
using Gorkem_.EndpointTags;
using Gorkem_.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.SecimTest
{
    public static class CreateSecimTesti
    {
        public record Command (SecimTestiEkleRequest Request) : IRequest<Result<int>>
        {

        }
        public class CreateSecimTestiValidation : AbstractValidator<Command>
        {
            public CreateSecimTestiValidation()
            {
                RuleFor(r => r.Request.KopekId).NotEmpty().NotNull().WithMessage("Kopek Id boş bırakılamaz");
                RuleFor(r => r.Request.SecimTestId).NotEmpty().NotNull().WithMessage("Seçim Testi Id boş bırakılamaz");
                RuleFor(r => r.Request.ToplamPuan).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100).WithMessage("Toplam puan 0 ile 100 arasında olmalıdır..");

            }
        }


        public static UT_SecimTest ToSecimTesti(this Command command)
        {
            return new UT_SecimTest
            {
                T_Aktif=DateTime.Now,
                Aktifmi = true,
                KopekId = command.Request.KopekId,
                SecimTestId = command.Request.SecimTestId,
                SinavYeriId = command.Request.SinavYeriId,
                Tarih = command.Request.Tarih,
                TepkiSekli = command.Request.TepkiSekli,
                Havlama = command.Request.Havlama,
                SecimTestBrans = command.Request.SecimTestBrans,
                Degerlendirme = command.Request.Degerlendirme,
                KomisyonId = command.Request.KomisyonId,
                ToplamPuan = command.Request.ToplamPuan
            };
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<int>>
        {
            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_SecimTests.Any(r => r.Id == request.Request.Id);
                if (isExist) return await Result<int>.FailAsync($"{request.Request.Id} numaralı test zaten var..");

                var kopek = await Context.UT_Kopek_Kopeks.FindAsync(request.Request.KopekId);
                if (kopek==null)
                {
                    return await Result<int>.FailAsync("Kopek bulunamadı");
                }
                if (kopek.KopekDurum == Enum_KopekDurum.SaglikRed)
                {
                    return await Result<int>.FailAsync("Köpeğin durumu sağlık red olduğu için seçilemez..");
                }


                var secimTesti = request.ToSecimTesti();
                kopek.KopekDurum = Enum_KopekDurum.KursHazirlik;

                if (request.Request.ToplamPuan < 60 )
                {
                    kopek.KopekDurum = Enum_KopekDurum.SecimTestiRed;
                    Context.UT_SecimTests.Add(secimTesti);
                    await Context.SaveChangesAsync(cancellationToken);
                    return await Result<int>.SuccessAsync(secimTesti.Id);
                }


                Context.UT_SecimTests.Add(secimTesti);

                var isSaved = await Context.SaveChangesAsync() > 0;
                if (isSaved)
                {
                    var kopekDurum = await Context.UT_Kopek_Kopeks.FindAsync(request.Request.KopekId);
                    if(kopekDurum != null)
                    {
                        kopekDurum.KopekDurum = Enum_KopekDurum.KursHazirlik;
                        await Context.SaveChangesAsync(cancellationToken);
                    }


                    Logger.Information("{0} kaydı {1} tarafından {2} tarihinde eklendi..", request.Request.Id, "DemoAccount", DateTime.Now);
                    return await Result<int>.SuccessAsync(secimTesti.Id);
                }
                return await Result<int>.FailAsync("Kayıt başarılı değil");

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
