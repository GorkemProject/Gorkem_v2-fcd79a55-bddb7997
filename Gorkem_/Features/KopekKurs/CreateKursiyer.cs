using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class CreateKursiyer
    {

        public record Command(KursiyerKaydetRequest Request) : IRequest<Result<int>> 
        {

        }


        public class CreateKursiyerValidator : AbstractValidator<Command>
        {
            public CreateKursiyerValidator()
            {
                RuleFor(r => r.Request.PersonelAdi).NotEmpty().NotEmpty().WithMessage("Perseonel Adını  boş geçemezsiniz");
                RuleFor(r => r.Request.Sicil).NotEmpty().NotEmpty().WithMessage("Perseonel sicilini boş geçemezsiniz");
                RuleFor(r => r.Request.KursId).NotEmpty().NotEmpty().WithMessage("hangi kursa kayıt olacağını boş geçemezsiniz");
                RuleFor(r => r.Request.CipNumarası).NotEmpty().NotEmpty().WithMessage("çip numarasını  boş geçemezsiniz");
                



            }
        }


        public static UT_Kursiyer ToKursiyer(this Command command, int kopekId)
        {
            return new UT_Kursiyer
            {
                PersonelAdi = command.Request.PersonelAdi,
                Sicil = command.Request.Sicil,
                KursId = command.Request.KursId,
                CipNumarası = command.Request.CipNumarası,
                KopekId= kopekId,
                Aktifmi = true,
                T_Aktif = DateTime.Now,
            };
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<int>>
        {
            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var kopek = await Context.UT_Kopek_Kopeks.FirstOrDefaultAsync(k => k.CipNumarasi == request.Request.CipNumarası);
                if (kopek == null)
                {
                    return await Result<int>.FailAsync("Girilen çip numarasına sahip bir köpek bulunamadı.");
                }

                var isAlreadyEnrolled = await Context.UT_Kursiyer.AnyAsync(k => k.KopekId == kopek.Id && k.KursId == request.Request.KursId);
                
                    if (isAlreadyEnrolled)
                    {
                    return await Result<int>.FailAsync("Bu köpek ve kursiyer zaten bu kursa eklenmiş..");
                    }
                

                var isExist = Context.UT_Kursiyer.Any(r => r.Id == request.Request.Id);
                if (isExist) return await Result<int>.FailAsync($"{request.Request.Id} zaten var");

                var kursiyer = Context.UT_Kursiyer.Add(request.ToKursiyer(kopek.Id));
                kopek.KopekDurum = Enums.Enum_KopekDurum.Kurs;

                var isSaved = await Context.SaveChangesAsync() > 0;

                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} tarihinde eklendi", request.Request.Id, "DemoAccount", DateTime.Now);
                    return await Result<int>.SuccessAsync(kursiyer.Entity.Id);
                }
                return await Result<int>.FailAsync("kayıt başarılı değil");
            }
        }
    }
    public class CreateKursiyerEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/CreateKursiyer", async ([FromBody] KursiyerKaydetRequest model, ISender sender) =>
            {
                var request = new CreateKursiyer.Command(model) ;

                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }

}
