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
    public static class AddKGRMufredatToKursGunlukRapor
    {
        public record AddKGRMufredatToKursGunlukRaporCommand(KursGunlukRaporaKGRMufredatEkle Request) : IRequest<Result<bool>>;

        internal sealed class AddKGRMufredatToKursGunlukRaporHandler : IRequestHandler<AddKGRMufredatToKursGunlukRaporCommand, Result<bool>>
        {
            private GorkemDbContext _context;

            public AddKGRMufredatToKursGunlukRaporHandler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(AddKGRMufredatToKursGunlukRaporCommand request, CancellationToken cancellationToken)
            {
                var existingKursGunlukRapor = await _context.UT_KursGunlukRapors
                    .Include(a => a.KGRMufredatlar)
                    .FirstOrDefaultAsync(a => a.Id == request.Request.KursGunlukRaporId);

                if (existingKursGunlukRapor == null)
                {
                    return await Result<bool>.FailAsync("Seçilen Kurs Günlük Raporu bulunamadı");
                }

                existingKursGunlukRapor.KGRMufredatlar?.Clear();

                foreach (var kgrMufredat in request.Request.KGRMufredatlarId)
                {
                    var mufredat = await _context.UT_KGRMufredats
                        .FirstOrDefaultAsync(u => u.Id == kgrMufredat);

                    if (mufredat == null)
                    {
                        return await Result<bool>.FailAsync($"Seçilen KGRMufredat bulunamadı.. : {kgrMufredat}");
                    }
                    existingKursGunlukRapor.KGRMufredatlar?.Add(mufredat);
                }

                var isSaved = await _context.SaveChangesAsync() > 0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);

                return await Result<bool>.FailAsync("Günlük rapora müfredat eklenemedi..");
            }
        }
    }
    public class AddKGRMufredatToGunlukRaporEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/AddKGRMufredatToKursGunlukRapor", async ([FromBody] KursGunlukRaporaKGRMufredatEkle model, ISender sender) =>
            {
                var request = new AddKGRMufredatToKursGunlukRapor.AddKGRMufredatToKursGunlukRaporCommand(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);


            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }

}
