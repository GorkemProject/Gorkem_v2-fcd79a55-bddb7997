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
    public static class AddEgitmenToKurs
    {

        public record AddEgitmenToKursCommand(KursaEgitmenEkleRequest Request) : IRequest<Result<bool>>;

        internal sealed class AddEgitmenToKursHandler : IRequestHandler<AddEgitmenToKursCommand, Result<bool>>
        {

            private readonly GorkemDbContext _context;

            public AddEgitmenToKursHandler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(AddEgitmenToKursCommand request, CancellationToken cancellationToken)
            {
                var existingKurs = await _context.UT_Kurs
                    .Include(a => a.KursEgitmenler)
                    .FirstOrDefaultAsync(k => k.Id == request.Request.KursId);

                if (existingKurs == null)
                {
                    return await Result<bool>.FailAsync("Seçilen komisyon bulunamadı");
                }

                //existingKurs.KursEgitmenler?.Clear();

                foreach (var egitmenId in request.Request.EgitmenIds)
                {
                    var egitmen = await _context.UT_KursEgitmenler
                        .FirstOrDefaultAsync(u => u.Id == egitmenId);
                    if(egitmen == null)
                    {
                        return await Result<bool>.FailAsync($"Seçilen eğitmen bulunamadı: {egitmenId}");
                    }

                    existingKurs.KursEgitmenler?.Add(egitmen);
                }

                var isSaved = await _context.SaveChangesAsync()>0;

                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);

                return await Result<bool>.FailAsync("Kursa eğitmen eklenemedi");
            }
        }
    }
    public class AddEgitmenToKursEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/AddEgitmenToKurs", async ([FromBody] KursaEgitmenEkleRequest model, ISender sender) =>
            {
                var request = new AddEgitmenToKurs.AddEgitmenToKursCommand(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
                
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
