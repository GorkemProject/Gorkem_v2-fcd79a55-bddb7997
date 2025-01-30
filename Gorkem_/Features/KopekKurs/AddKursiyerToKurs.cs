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
    public static class AddKursiyerToKurs
    {

        public record AddKursiyerToKursCommand(KursaKursiyerEkleRequest Request) : IRequest<Result<bool>>;

        internal sealed class AddEgitmenToKursHandler : IRequestHandler<AddKursiyerToKursCommand, Result<bool>>
        {
            private readonly GorkemDbContext _context;

            public AddEgitmenToKursHandler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(AddKursiyerToKursCommand request, CancellationToken cancellationToken)
            {
                var existingKurs = await _context.UT_Kurs
                    .Include(a => a.Kursiyerler)
                    .FirstOrDefaultAsync(k => k.Id == request.Request.KursId);

                if (existingKurs == null)
                {
                    return await Result<bool>.FailAsync("Seçilen kurs bulunamadı..");
                }

                existingKurs.Kursiyerler?.Clear();

                foreach (var kursiyerId in request.Request.KursiyerIds)
                {
                    var kursiyer = await _context.UT_Kursiyer
                        .FirstOrDefaultAsync(u => u.Id == kursiyerId);

                    if (kursiyer == null)
                    {
                        return await Result<bool>.FailAsync($"Secilen kursiyer bulunamadı: {kursiyerId}");

                    }

                    existingKurs.Kursiyerler?.Add(kursiyer);
                }

                var isSaved = await _context.SaveChangesAsync() > 0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync();
                return await Result<bool>.FailAsync("Kursa kursiyer eklenemedi");

            }
        }
    }

    public class AddKursiyerToKursEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapPost("kopekKurs/AddKursiyerToKurs", async ([FromBody] KursaKursiyerEkleRequest command, ISender sender) =>
             {
                 var request = new AddKursiyerToKurs.AddKursiyerToKursCommand(command);
                 var response = await sender.Send(request);
                 if (response.Succeeded)
                     return Results.Ok(response);
                 return Results.BadRequest(response);


             }).WithTags(EndpointConstants.KOPEKKURS);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
