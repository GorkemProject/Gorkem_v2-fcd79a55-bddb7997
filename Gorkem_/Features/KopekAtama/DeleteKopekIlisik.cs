using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekAtama
{
    public static class DeleteKopekIlisik
    {
        public record Command(int KopekId) : IRequest<Result<bool>>;

        internal sealed class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                //İlişik kesilecek köpeği bul
                var kopek = await _context.UT_Kopek_Kopeks
                    .FirstOrDefaultAsync(k=>k.Id==request.KopekId);

                if (kopek == null)
                {
                    return await Result<bool>.FailAsync("Belirtilen köpek bulunamadı..");
                }

                var kopekCalKad = await _context.UT_KopekCalKads
                    .Where(k=>k.KopekId == request.KopekId && k.Aktifmi)
                    .FirstOrDefaultAsync();

                if (kopekCalKad != null)
                {
                    kopekCalKad.Aktifmi = false;
                    kopekCalKad.T_IlisikKesme = DateTime.Now;
                    kopekCalKad.T_Pasif = DateTime.Now;
                    kopekCalKad.AtamaTuru = Enums.Enum_AtamaTuru.IlisikKesme;
                    kopekCalKad.BirimId = null;
                    
                }
                kopek.BirimId = null;

                var isSaved = await _context.SaveChangesAsync()>0;

                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Köpeğin ilişiği kesilemedi");

            }
        }
    }
    public class DeleteKopekIlisikEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekAtama/DeleteKopekIlisik", async (int kopekId, ISender sender) =>
            {
                var request = new DeleteKopekIlisik.Command(kopekId);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response); 

            }).WithTags(EndpointConstants.KOPEKATAMA);
        }
    }
}
