using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;
using static Gorkem_.Features.Komisyon.AddMultipleUyeToKomisyon;

namespace Gorkem_.Features.Komisyon
{
    public static class AddMultipleUyeToKomisyon
    {
        public record AddMultipleUyeToKomisyonCommand(KomisyonaBirdenFazlaUyeEkle Request) : IRequest<Result<bool>>;

        internal sealed class AddMultipleUyeToKomisyonHandler : IRequestHandler<AddMultipleUyeToKomisyonCommand, Result<bool>>
        {
            private readonly GorkemDbContext _context;

            public AddMultipleUyeToKomisyonHandler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(AddMultipleUyeToKomisyonCommand request, CancellationToken cancellationToken)
            {
                var existingKomisyon = await _context.UT_Komisyons
                    .Include(k => k.KomisyonUyeleri)
                    .FirstOrDefaultAsync(k => k.Id == request.Request.KomisyonId);

                if (existingKomisyon == null)
                {
                    return await Result<bool>.FailAsync("Seçilen komisyon bulunamadı");
                }

                foreach (var uyeId in request.Request.KomisyonUyeleriIds)
                {
                    var uye = await _context.UT_KomisyonUyeleris
                        .FirstOrDefaultAsync(u => u.Id == uyeId);

                    if (uye==null)
                    {
                        return await Result<bool>.FailAsync($"Seçilen üye bulunamadı: {uyeId}");
                    }

                    existingKomisyon.KomisyonUyeleri?.Add(uye);
                }
                var isSaved = await _context.SaveChangesAsync()>0;
                
                if (isSaved) 
                    return await Result<bool>.SuccessAsync(true);


                return await Result<bool>.FailAsync("Komisyona üye yüklenemedi");
            }
        }
    }

    public class AddMultipleUyeToKomisyonEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("komisyon/uyeler", async ([FromBody] KomisyonaBirdenFazlaUyeEkle request, ISender sender) =>
            {
                var response = await sender.Send(new AddMultipleUyeToKomisyonCommand(request));
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response.Message);


            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
