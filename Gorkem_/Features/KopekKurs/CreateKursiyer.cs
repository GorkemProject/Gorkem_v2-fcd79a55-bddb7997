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
    public static class CreateKursiyer
    {

        public class Command : IRequest<Result<bool>> 
        {
            public int IdareciId { get; set; }
        }


        public class CreateKursiyerValidator : AbstractValidator<Command>
        {
            public CreateKursiyerValidator()
            {
                RuleFor(x => x.IdareciId).NotEmpty().WithMessage("Idareci Id gereklidir.");
            }
        }

        public class CreateKursiyerHandler : IRequestHandler<Command, Result<bool>>
        {
            public readonly GorkemDbContext _context;

            public CreateKursiyerHandler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var idareci = await _context.UT_Idarecis.FindAsync(request.IdareciId);

                if (idareci==null)
                {
                    return Result<bool>.Fail("Geçersiz id değeri girildi");
                }
               
                var kursiyer = new UT_Kursiyer
                {
                    Idareci = idareci,
                };
                kursiyer.Aktifmi = true;
                kursiyer.T_Aktif = DateTime.Now;

                _context.UT_Kursiyer.Add(kursiyer);
                await _context.SaveChangesAsync(cancellationToken);


                return await Result<bool>.SuccessAsync(true);
            }
        }

    }
    public class CreateKursiyerEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/CreateKursiyer", async ([FromBody] CreateKursiyerCommand model, ISender sender) =>
            {
                var request = new CreateKursiyer.Command() { IdareciId = model.IdareciId};

                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }

}
