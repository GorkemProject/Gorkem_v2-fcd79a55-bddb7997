using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KopekAtama;
using Gorkem_.EndpointTags;
using Gorkem_.Enums;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekAtama
{
    public static class AddBirimToKopek
    {
        public record Command(KopegeBirimEkleRequest Request) : IRequest<Result<bool>>;

        internal class Validate : AbstractValidator<Command>
        {
            public Validate()
            {
                RuleFor(r => r.Request.KopekId).GreaterThan(0).WithMessage("Birim eklenecek köpeği seçmelisin");
                RuleFor(r => r.Request.BirimTabloID).GreaterThan(0).WithMessage("Köpeğe eklenecek birimi seçmelisin");

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
                //Köpeği bulduk
                var kopek = await _context.UT_Kopek_Kopeks
                    .Include(k => k.Idareci)
                    .Include(k => k.Birim)
                    .FirstOrDefaultAsync(k => k.Id == request.Request.KopekId);

                if (kopek == null)
                {
                    return await Result<bool>.FailAsync("Seçtiğiniz köpek bulunamadı");

                }

                //Birimi bulduk
                var birim = await _context.KT_Birims
                    .FirstOrDefaultAsync(k => k.Id == request.Request.BirimTabloID);

                if (birim == null)
                {
                    return await Result<bool>.FailAsync("Seçilen birim bulunamadı");
                }


                var idareciKopekleri = await _context.UT_IdareciKopekleri
                    .FirstOrDefaultAsync(k => k.KopekId == request.Request.KopekId && k.Aktifmi);

                if (idareciKopekleri == null)
                {
                    return await Result<bool>.FailAsync("Seçilen köpeğin idarecisi bulunamadı..");

                }

                //Köpeğin daha önce çalıştığı kadro var mı?
                var mevcutCalKad = await _context.UT_KopekCalKads
                    .Where(k => k.KopekId == kopek.Id && k.Aktifmi)
                    .FirstOrDefaultAsync();

                if (mevcutCalKad != null)
                {
                    mevcutCalKad.Aktifmi = false;
                    mevcutCalKad.T_IlisikKesme = DateTime.Now;
                    mevcutCalKad.T_Pasif = DateTime.Now;

                }



                //Birimi köpeğe ekliyoruz
                kopek.BirimId = birim.Id;
                kopek.Birim = birim;

                //Köpeğin durumunu kurs hazırlık olarak değiştiriyoruz

                //kopek.KopekDurum = Enum_KopekDurum.KursHazirlik;



                var kopekCalKad = new UT_KopekCalKad
                {
                    KopekId = kopek.Id,
                    AdayIdareciId = idareciKopekleri.AdayIdareciId,
                    Aktifmi = true,
                    T_Aktif = DateTime.Now,
                    T_GoreveBaslama = DateTime.Now,
                    T_EvrakAtama = DateTime.Now,
                    T_IlisikKesme = null,
                    AtamaEvrakSayısı = request.Request.AtamaEvrakSayisi,
                    AtamaTuru = request.Request.AtamaTuru,
                    BirimId = birim.Id,


                };

                _context.UT_KopekCalKads.Add(kopekCalKad);



                var isSaved = await _context.SaveChangesAsync() > 0;

                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Köpeğe birim eklenemedi.");

            }
        }
    }

    public class AddBirimToKopekEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapPost("kopekAtama/addBirimToKopek", async ([FromBody] KopegeBirimEkleRequest request, ISender sender) =>
            {
                var response = await sender.Send(new AddBirimToKopek.Command(request));
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKATAMA);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
