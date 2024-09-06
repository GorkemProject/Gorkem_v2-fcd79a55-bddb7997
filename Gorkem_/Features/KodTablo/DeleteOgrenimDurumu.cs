using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Gorkem_.Features.KodTablo
{
    public static class DeleteOgrenimDurumu
    {
        public class Command : IRequest<Result<bool>> { public int Id { get; set; } }

        public class DeleteOgrenimDurumuValidation : AbstractValidator<Command>
        {

            public DeleteOgrenimDurumuValidation()
            {
                RuleFor(r => r.Id).GreaterThanOrEqualTo(0).Configure(r => r.MessageBuilder = _ => "Id Boş Olamaz.");
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
                var currentBirim = await _context.KT_OgrenimDurumus.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentBirim is null) return await Result<bool>.FailAsync($"With the {request.Id} Id data could not found");

                currentBirim.Aktifmi = false;
                currentBirim.T_Pasif=DateTime.Now;
                var isDeleted = await _context.SaveChangesAsync() > 0;

                if (isDeleted)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Silme işlemi yapılamadı");
            }
        }
    }
    public class DeleteOgrenimDurumuEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("kodtablo/ogrenimdurum", async ([FromBody] OgrenimDurumuSilRequest model, ISender sender) =>
            {
                var request = new DeleteOgrenimDurumu.Command() { Id = model.Id };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok($"With the {model.Id} id data has been deleted");
                return Results.BadRequest(response.Message);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }

}
