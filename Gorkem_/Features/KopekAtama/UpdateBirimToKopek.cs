using AspNetCoreHero.Results;
using Azure.Core;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekAtama;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekAtama
{
    public static class UpdateBirimToKopek
    {
        public record class Command (int KopekId, int BirimId) : IRequest<Result<bool>>;

        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {

                //köpeği bul
                var kopek = await _context.UT_Kopek_Kopeks
                    .FirstOrDefaultAsync(k => k.Id == request.KopekId, cancellationToken);

                if (kopek == null)
                    return await Result<bool>.FailAsync("Köpek bulunamadı..");


                //birimi bul
                var birim = await _context.KT_Birims
                    .FirstOrDefaultAsync(b => b.Id == request.BirimId, cancellationToken);

                if (birim == null)
                    return await Result<bool>.FailAsync("Birim bulunamadı..");

                kopek.BirimId = request.BirimId;
                
                var isSaved = await _context.SaveChangesAsync(cancellationToken)>0;

                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);

                return await Result<bool>.FailAsync("Birim Güncellenemedi..");
                    
            }
        }

    }

    public class UpdateBirimToKopekEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("kopekAtama/updateBirimToKopek", async ( [FromBody] KopeginBiriminiGuncelleRequest model, ISender sender) =>
            {
                var response = await sender.Send(new UpdateBirimToKopek.Command(model.KopekId, model.BirimId));

                if (response.Succeeded)
                    return Results.Ok(response);

                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKATAMA);
        }
    }
}
