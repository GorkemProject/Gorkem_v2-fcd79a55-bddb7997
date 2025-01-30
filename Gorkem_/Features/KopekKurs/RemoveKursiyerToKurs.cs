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
    public static class RemoveKursiyerToKurs
    {
        public record Command(KurstanKursiyerCikartRequest Request) : IRequest<Result<bool>>;

        internal sealed class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var existingKurs = await _context.UT_Kurs
                    .Include(k => k.Kursiyerler)
                    .FirstOrDefaultAsync(k => k.Id == request.Request.KursId);

                if (existingKurs == null)
                {
                    return await Result<bool>.FailAsync("Seçilen kurs bulunamadı..");
                }

                foreach (var kursiyerId in request.Request.KursiyerIds)
                {
                    var kursiyer = existingKurs.Kursiyerler?.FirstOrDefault(e => e.Id == kursiyerId);
                    if (kursiyer == null)
                    {
                        return await Result<bool>.FailAsync($"Seçilen kursiyer herhangi bir kursa atanmamış");
                    }
                    existingKurs.Kursiyerler?.Remove(kursiyer);
                }
                var isSaved = await _context.SaveChangesAsync() > 0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);

                return await Result<bool>.FailAsync("Kurstan kursiyer çıkartılamadı");
            }
        }
    }
    public class RemoveKursiyerToKursEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapPost("kopekKurs/RemoveKursiyerToKurs", async ([FromBody] KurstanKursiyerCikartRequest model, ISender sender) =>
             {
                 var request = new RemoveKursiyerToKurs.Command(model);
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
