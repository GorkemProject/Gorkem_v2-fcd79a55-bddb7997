using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Gorkem_.Features.KopekKurs
{
    public static class AddGozlemToKursHaftalikRapor
    {

        public record AddGozlemToKursHaftalikRaporCommand(GozlemleriKursHaftalikRaporaEkle  Request) : IRequest<Result<bool>>;

        internal sealed class AddGozlemToKursHaftalikRaporHandler : IRequestHandler<AddGozlemToKursHaftalikRaporCommand, Result<bool>>
        {
            private GorkemDbContext _context;

            public AddGozlemToKursHaftalikRaporHandler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(AddGozlemToKursHaftalikRaporCommand request, CancellationToken cancellationToken)
            {
                var existintHaftalikRapor = await _context.UT_KursHaftalıkDegerlendirmeRaporus
                    .Include(a => a.HaftalıkDegerlendirmeRaporuGozlemler)
                    .FirstOrDefaultAsync(a => a.Id == request.Request.KursHaftalikRaporId);

                if (existintHaftalikRapor == null)
                {
                    return await Result<bool>.FailAsync("Seçilen kurs haftalık rapor bulunamadı");
                }
                existintHaftalikRapor.HaftalıkDegerlendirmeRaporuGozlemler?.Clear();
                foreach (var gozlems in request.Request.GozlemlerId)
                {
                    var gozlem = await _context.UT_HaftalıkDegerlendirmeRaporuGozlemlers
                        .FirstOrDefaultAsync(u => u.Id == gozlems);

                    if (gozlem == null)
                    {
                        return await Result<bool>.FailAsync($"Seçilen gözlem bulunamadı.. : {gozlems}");

                    }
                    existintHaftalikRapor.HaftalıkDegerlendirmeRaporuGozlemler?.Add(gozlem);

                }

                var isSaved = await _context.SaveChangesAsync() > 0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Haftalık rapora gözlem eklenemedi..");
            }
        }
    }
    public class AddGozlemToKursHaftalikRaporEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/AddGozlemToHaftalikRapor", async ([FromBody] GozlemleriKursHaftalikRaporaEkle model, ISender sender) =>
            {
                var request = new AddGozlemToKursHaftalikRapor.AddGozlemToKursHaftalikRaporCommand(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
