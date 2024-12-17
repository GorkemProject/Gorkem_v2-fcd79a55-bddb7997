using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Kopek;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Kopek
{
    public static class AddKuvveNoToKopek
    {
        public record Command(KopegeKuvveNumarasiEkle Request) : IRequest<Result<bool>>;

        internal class Validate : AbstractValidator<Command>
        {
            public Validate()
            {
                RuleFor(r => r.Request.KopekId).GreaterThan(0).WithMessage("Hangi köpeğe kuvve numarasi ekleyeceğinizi seçmelisiniz");
                RuleFor(r => r.Request.KuvveNumarasi).NotNull().NotEmpty().WithMessage("Köpeğe eklencek kuvve numarasını belirtmelisiniz");
                RuleFor(r => r.Request.EbysEvrakSayisi).NotNull().NotEmpty().WithMessage("Köpeğe eklencek kuvve numarasının evrak sayısını belirtmelisiniz");
                RuleFor(r => r.Request.EbysEvrakTarihi).NotNull().NotEmpty().WithMessage("Köpeğe eklencek kuvve numarasının evrak tarihi belirtmelisiniz");
                RuleFor(r => r.Request.BransId).NotNull().NotEmpty().WithMessage("Köpeğe eklencek kuvve numarasının evrak tarihi belirtmelisiniz");
                

            }
        }

        internal sealed class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {

                try
                {
                    // Mevcut işlemi kullanmak için transaction başlatmayın
                    var kopek = await _context.UT_Kopek_Kopeks
                        .Where(a => a.Aktifmi == true)
                        .FirstOrDefaultAsync(k => k.Id == request.Request.KopekId, cancellationToken);

                    if (kopek == null)
                    {
                        return await Result<bool>.FailAsync("Seçtiğiniz köpek bulunamadı");
                    }

                    if (!string.IsNullOrEmpty(kopek.KuvveNumarasi))
                    {
                        return await Result<bool>.FailAsync("Bu köpeğe zaten bir kuvve numarası eklenmiş");
                    }

                    // Köpek tablosunu güncelle
                    kopek.KuvveNumarasi = request.Request.KuvveNumarasi;
                    kopek.KopekDurum = Enums.Enum_KopekDurum.KopekKuvve;
                    kopek.BransId = request.Request.BransId;

                    // Detay tablosuna ekleme
                    var kuvveDetay = new UT_KopekKuvveDetay
                    {
                        KopekId = kopek.Id,
                        KuvveNo = request.Request.KuvveNumarasi,
                        EbysEvrakTarihi = request.Request.EbysEvrakTarihi,
                        EbysEvrakSayisi = request.Request.EbysEvrakSayisi,
                        Aktifmi=true,
                        T_Aktif=DateTime.Now
                    };

                    _context.UT_Kopek_Kopeks.Update(kopek);
                    await _context.UT_KopekKuvveDetays.AddAsync(kuvveDetay, cancellationToken);

                    var isSaved = await _context.SaveChangesAsync(cancellationToken) > 0;

                    if (isSaved)
                        return await Result<bool>.SuccessAsync(true, "Kuvve numarası ve detayları başarıyla eklendi.");
                    return await Result<bool>.FailAsync("Kuvve numarası eklenirken bir hata oluştu");
                }
                catch (Exception ex)
                {
                    return await Result<bool>.FailAsync($"Bir hata oluştu: {ex.Message}");
                }

            }
        }
    }

    public class AddKuvveNoToKopekEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("kopek/addKopekToKuvveNo", async ([FromBody] KopegeKuvveNumarasiEkle model, ISender sender ) =>
            {
                var request = new AddKuvveNoToKopek.Command(model);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEK);
        }
    }
}
