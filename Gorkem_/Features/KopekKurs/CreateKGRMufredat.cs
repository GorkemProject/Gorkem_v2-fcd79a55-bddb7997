using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.KopekKurs
{
    public static class CreateKGRMufredat
    {
        public class Command : IRequest<Result<bool>>
        {
            public int MufredatId { get; set; }
        }

        public class CreateKGRMufredatValidation : AbstractValidator<Command>
        {
            public CreateKGRMufredatValidation()
            {
                RuleFor(r => r.MufredatId).NotEmpty().NotNull().WithMessage("Mufredat id gereklidir..");
            }
        }

        public class CreaateKGRMufredatHandler : IRequestHandler<Command, Result<bool>>
        {
            private readonly GorkemDbContext _context;

            public CreaateKGRMufredatHandler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var mufredat = await _context.KT_KursMufredats.FindAsync(request.MufredatId);
                if (mufredat==null)
                {
                    return Result<bool>.Fail("Geçersiz bir id değeri girildi");
                }

                var kgrMufredat = new UT_KGRMufredat
                {
                    Mufredat = mufredat,
                };
                kgrMufredat.Aktifmi = true;
                kgrMufredat.T_Aktif=DateTime.Now;

                _context.UT_KGRMufredats.Add(kgrMufredat);
                await _context.SaveChangesAsync(cancellationToken);

                return await Result<bool>.SuccessAsync(true);
            }

        }
    }
    public class CreateKGRMufredatEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/CreateKGRMufredat", async ([FromBody] CreateKGRMufredatCommand model, ISender sender ) =>
            {
                var request = new CreateKGRMufredat.Command() {MufredatId=model.MufredatId };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }

}
