using System.Drawing.Text;
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
    public static class AddKopekCevapToIdareciVeKopekDegerlendirmeFormu
    {
        public record AddKopekCevapToIdareciVeKopekDegerlendirmeFormuCommand(IdareciVeKopekDegerlendirmeFormunaKopekCevapEkle Request): IRequest<Result<bool>>;

        internal sealed class AddKopekCevapToIdareciVeKopekDegerlendirmeFormuHandler : IRequestHandler<AddKopekCevapToIdareciVeKopekDegerlendirmeFormuCommand, Result<bool>>
        {
            private readonly GorkemDbContext _context;

            public AddKopekCevapToIdareciVeKopekDegerlendirmeFormuHandler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(AddKopekCevapToIdareciVeKopekDegerlendirmeFormuCommand request, CancellationToken cancellationToken)
            {
                var existingForm = await _context.UT_KopekVeIdareciDegerlendirmeFormu
                     .Include(a => a.KopekDegerlendirmeCevaplar)
                     .FirstOrDefaultAsync(k => k.Id == request.Request.DegerlendirmeFormId);

                if (existingForm == null)
                {
                    return await Result<bool>.FailAsync("Seçilen değerlendirme formu bulunamadı");

                } 
                existingForm.KopekDegerlendirmeCevaplar?.Clear();

                foreach (var cevapId in request.Request.KopekCevapId)
                {
                    var cevap = await _context.UT_KursKopekDegerlendirmeCevap
                        .FirstOrDefaultAsync(u => u.Id == cevapId);
                    if (cevap == null)
                    {
                        return await Result<bool>.FailAsync($"Seçilen cevap bulunamadı : {cevapId } ");
                    }
                    existingForm.KopekDegerlendirmeCevaplar?.Add(cevap);
                }
                var isSaved = await _context.SaveChangesAsync() > 0;

                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Forma cevap eklenemedi");
            }
        }
    }
    public class AddKopekCevapToIdareciVeKopekDegerlendirmeFormuEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/AddKopekCevapToIdareciVeKopekDegerlendirmeFormu", async ([FromBody] IdareciVeKopekDegerlendirmeFormunaKopekCevapEkle model, ISender sender) =>
            {
                var request = new AddKopekCevapToIdareciVeKopekDegerlendirmeFormu.AddKopekCevapToIdareciVeKopekDegerlendirmeFormuCommand(model);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }

}
