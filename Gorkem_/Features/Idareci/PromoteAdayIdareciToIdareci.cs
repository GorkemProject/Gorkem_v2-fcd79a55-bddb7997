using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Idareci
{
    public static class PromoteAdayIdareciToIdareci
    {
        public record Command(AdayIdareciyiIdareciYapRequest Request) : IRequest<Result<bool>>
        {

        }


        internal class PromoteAdayIdareciToIdareciCommandValidator : AbstractValidator<Command>
        {
            public PromoteAdayIdareciToIdareciCommandValidator()
            {
                RuleFor(x => x.Request.AdayIdareciId).GreaterThan(0).WithMessage("Geçerli bir Aday İdareci ID'si girilmelidir.");
                RuleFor(x => x.Request.EbysEvrakTarihi).NotEmpty().WithMessage("EBYS Evrak Tarihi boş olamaz.");
                RuleFor(x => x.Request.EbysEvrakSayisi).NotEmpty().WithMessage("EBYS Evrak Sayısı boş olamaz.");
            }
        }

        public class Handler : IRequestHandler<Command, Result<bool>>
        {

            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var adayIdareci = await _context.UT_AdayIdareci
                    .FirstOrDefaultAsync(x => x.Id == request.Request.AdayIdareciId, cancellationToken);

                if (adayIdareci == null)
                    throw new Exception("Aday İdareci bulunamadı");

                if (adayIdareci.Durum != Enums.Enum_AdayPersonelDurum.Basarili)
                    throw new Exception("Bu  aday idareci, idareci olmaya uygun değildir.");


                var idareci = new UT_Idareci
                {
                    Aktifmi = true,
                    T_Aktif = DateTime.Now,
                    EbysEvrakSayisi = request.Request.EbysEvrakSayisi,
                    EbysEvrakTarihi = request.Request.EbysEvrakTarihi,
                    IdareciId = adayIdareci.Id,

                };

                await _context.UT_Idarecis.AddAsync(idareci, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
                return await Result<bool>.SuccessAsync(true);
            }
        }

    }

    public class PromoteAdayIdareciToIdareciEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("idareci/PromoteAdayIdareciToIdareci", async ([FromBody] AdayIdareciyiIdareciYapRequest model, ISender sender) =>
            {
                var request = new PromoteAdayIdareciToIdareci.Command(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);

                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.IDARECI);
        }
    }
}
