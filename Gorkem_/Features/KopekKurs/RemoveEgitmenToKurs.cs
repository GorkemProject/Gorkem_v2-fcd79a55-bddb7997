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
    public static class RemoveEgitmenToKurs
    {
        public record Command(KurstanEgitmenCıkartRequest Request) : IRequest<Result<bool>>;

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
                    .Include(a => a.KursEgitmenler)
                    .FirstOrDefaultAsync(k => k.Id == request.Request.KursId);

                if (existingKurs == null)
                {
                    return await Result<bool>.FailAsync("Seçilen kurs bulunamadı..");
                }

                foreach (var egitmenId in request.Request.EgitmenId)
                {
                    var egitmen = existingKurs.KursEgitmenler?.FirstOrDefault(e => e.Id == egitmenId);
                    if (egitmen == null)
                    {
                        return await Result<bool>.FailAsync($"Seçilen eğitmen herhangi bir kursa atanmamış");
                    }

                    existingKurs.KursEgitmenler?.Remove(egitmen);
                }
                var isSaved = await _context.SaveChangesAsync() > 0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);

                return await Result<bool>.FailAsync("Kurstan eğitim çıkartılamadı");
            }
        }
    }

    public class RemoveEgitmenToKursEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapPost("kopekKurs/RemoveEgitmenToKurs", async ([FromBody] KurstanEgitmenCıkartRequest model, ISender sender) =>
             {
                 var request = new RemoveEgitmenToKurs.Command(model);
                 var response = await sender.Send(request);

                 if (response.Succeeded)
                     return Results.Ok(response);
                 return Results.BadRequest(response);

             }).WithTags(EndpointConstants.KODTABLO);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
