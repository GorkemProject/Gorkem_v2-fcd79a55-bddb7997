using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class AddKursiyerCevapToIdareciVeKopekDegerlendirmeFormu
    {

        public record AddKursiyerCevapToIdareciVeKopekDegerlendirmeFormuCommand(IdareciVeKopekDegerlendirmeFormunaKursiyerCevapEkle Request) : IRequest<Result<bool>>;

        internal sealed class AddKursiyerCevapToIdareciVeKopekDegerlendirmeFormuHandler : IRequestHandler<AddKursiyerCevapToIdareciVeKopekDegerlendirmeFormuCommand, Result<bool>>
        {
            private readonly GorkemDbContext _context;

            public AddKursiyerCevapToIdareciVeKopekDegerlendirmeFormuHandler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(AddKursiyerCevapToIdareciVeKopekDegerlendirmeFormuCommand request, CancellationToken cancellationToken)
            {
                var existingForm = await _context.UT_KopekVeIdareciDegerlendirmeFormu
                    .Include(a => a.KursiyerDegerlendirmeCevaplar)
                    .FirstOrDefaultAsync(k => k.Id == request.Request.DegerlendirmFormId);

                if (existingForm == null)
                {
                    return await Result<bool>.FailAsync("Seçilen değerlendirme formu bulunamadı..");
                }
                //existingForm.KursiyerDegerlendirmeCevaplar?.Clear();

                foreach (var cevapId in request.Request.KursiyerCevapId)
                {

                    var cevap = await _context.UT_KursKursiyerDegerlendirmeCevap
                        .FirstOrDefaultAsync(u => u.Id == cevapId);
                    if (cevap == null)
                    {
                        return await Result<bool>.FailAsync($"Seçilen cevap bulunamadı : {cevapId}");
                    }
                    existingForm.KursiyerDegerlendirmeCevaplar?.Add(cevap); ;

                }
                var isSaved = await _context.SaveChangesAsync()>0;

                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Forma cevap eklenemedi");
            
            }
        }
    }

    public class AddKursiyerCevapToIdareciVeKopekDegerlendirmeFormuEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/AddKursiyerCevapToIdareciVeKopekDegerlendirmeFormu", async ([FromBody] IdareciVeKopekDegerlendirmeFormunaKursiyerCevapEkle model, ISender sender) =>
            {
                var request = new AddKursiyerCevapToIdareciVeKopekDegerlendirmeFormu.AddKursiyerCevapToIdareciVeKopekDegerlendirmeFormuCommand(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
