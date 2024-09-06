using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Idareci
{
    public class RemoveKopekFromIdareci
    {
        public record Command(IdarecidenKopekCikartRequest Request) : IRequest<Result<bool>> { }

        internal class RemoveKopekFromIdareciValidate : AbstractValidator<Command>
        {
            public RemoveKopekFromIdareciValidate()
            {
                RuleFor(r => r.Request.IdareciId).GreaterThan(0).WithMessage("İdareci Seçmelisiniz");
                RuleFor(r => r.Request.KopekId).GreaterThan(0).WithMessage("Kopek Seçmelisiniz");
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
                //İlgili idareci ve köpeği bulma
                var idareciKopek = await _context.UT_IdareciKopekleri
                    .FirstOrDefaultAsync(r => r.IdareciId == request.Request.IdareciId && r.KopekId == request.Request.KopekId);
                if (idareciKopek == null)
                    return await Result<bool>.FailAsync("Belirtilen köpek ya da idareci bulunamadı");
                idareciKopek.Aktifmi = false;
                idareciKopek.T_Pasif = DateTime.Now;

                _context.UT_IdareciKopekleri.Update(idareciKopek);
                var isDataRemoved = await _context.SaveChangesAsync()>0;

                if (isDataRemoved) return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Köpek idareciden çıkartılamadı");
               

            }
        }
    }
    public class RemoveKopekFromIdareciEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("idareciköpek", async ([FromBody] IdarecidenKopekCikartRequest request, ISender sender) =>
            {
                var response = await sender.Send(new RemoveKopekFromIdareci.Command(request));

                if (response.Succeeded)
                    return Results.Ok();

                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.IDARECI);
        }
    }
}
