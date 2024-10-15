using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.Komisyon
{
    public class UpdateKomisyonUyeleri
    {
        public class KomisyonUyeCommand : IRequest<Result<bool>>
        {
            public int Id { get; set; }
            public string? TcKimlikNo { get; set; }
            public string? AdSoyad { get; set; }
            public int? Sicil { get; set; }
            public string? GorevUnvani { get; set; }
            public string? GorevYeri { get; set; }
            public string? Eposta { get; set; }
            public string? CepTelefonu { get; set; }
        }
        public class UpdateKomisyonUyeleriValidation : AbstractValidator<KomisyonUyeCommand>
        {
            public UpdateKomisyonUyeleriValidation()
            {
                RuleFor(r => r.Id).NotEmpty().NotNull().WithMessage("Komisyon üyesinin Id numarası boş bırakılamaz.");
                RuleFor(r => r.TcKimlikNo).NotEmpty().NotNull().WithMessage("Komisyon üyesinin TC Kimlik numarası boş bırakılamaz.");
                RuleFor(r => r.AdSoyad).NotEmpty().NotNull().WithMessage("Komisyon üyesinin Ad ve Soyadı boş bırakılamaz.");
                RuleFor(r => r.GorevUnvani).NotEmpty().NotNull().WithMessage("Komisyon üyesinin Görev Ünvanı boş bırakılamaz.");
                RuleFor(r => r.GorevYeri).NotEmpty().NotNull().WithMessage("Komisyon üyesinin Görev Yeri boş bırakılamaz.");
                RuleFor(r => r.Eposta).NotEmpty().NotNull().WithMessage("Komisyon üyesinin Eposta Adresi boş bırakılamaz.");
                RuleFor(r => r.CepTelefonu).NotEmpty().NotNull().WithMessage("Komisyon üyesinin Telefon Numarası boş bırakılamaz.");

            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<KomisyonUyeCommand, Result<bool>>
        {
            public async Task<Result<bool>> Handle(KomisyonUyeCommand request, CancellationToken cancellationToken)
            {
                var komisyonUye = await Context.UT_KomisyonUyeleris.FindAsync(request.Id);
                if (komisyonUye == null)
                {
                    return await Result<bool>.FailAsync("Komisyon üyesi bulunamadı..");

                }
                komisyonUye.TcKimlikNo = request.TcKimlikNo;
                komisyonUye.AdSoyad = request.AdSoyad;
                komisyonUye.Sicil = request.Sicil;
                komisyonUye.GorevUnvani = request.GorevUnvani;
                komisyonUye.GorevYeri = request.GorevYeri;
                komisyonUye.Eposta = request.Eposta;
                komisyonUye.CepTelefonu = request.CepTelefonu;

                var isSaved = await Context.SaveChangesAsync(cancellationToken) > 0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} tarafından Güncellendi.", request.TcKimlikNo, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Komisyon Üyesi Gücellenme Başarısız");

            }
        }
    }
    public class UpdateKomisyonUyeleriEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("komisyonuyeleri/{id}", async (int id, [FromBody] UpdateKomisyonUyeleri.KomisyonUyeCommand model, ISender sender) =>
            {
                model.Id = id;
                var result = await sender.Send(model);
                if (result.Succeeded)
                {
                    return Results.Ok(result);
                }
                return Results.BadRequest(result);
            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
