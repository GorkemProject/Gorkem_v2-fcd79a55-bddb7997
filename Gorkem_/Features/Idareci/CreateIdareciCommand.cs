using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.Idareci
{
    public static class CreateIdareciCommand
    {
        public class Command : IRequest<Result<int>>
        {
            public string AdiSoyadi { get; set; }
            public int Sicil { get; set; }

        }

        public class IdareciValidator : AbstractValidator<Command>
        {

            public IdareciValidator()
            {
                RuleFor(r => r.AdiSoyadi).NotNull().WithMessage("Adı Boş Olamaz");
            }
        }

        internal sealed class Handler : IRequestHandler<Command, Result<int>>
        {
            private readonly GorkemDbContext context;

            public Handler(GorkemDbContext context)
            {
                this.context=context;
            }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                this.context.UT_Kopek_Kopeks.Add(new Context.Entities.UT_Kopek_Kopek
                {

                    YapilanIslem=request.AdiSoyadi
                });

                var response = await this.context.SaveChangesAsync();
                if (response>0)
                    return await Result<int>.SuccessAsync(response);
                return await Result<int>.FailAsync("Aynı Adda İdareci Var");

            }
        }

    }
    public class CreateIdareciCommandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("idareci", async ([FromBody] IdareciEkleRequest model, ISender sender) =>
            {
                var command = new CreateIdareciCommand.Command()
                {
                    AdiSoyadi=model.AdiSoyadi,
                    Sicil=model.Sicil
                };
                var request = await sender.Send(command);

                if (request.Succeeded)
                    return Results.Ok();
                return Results.BadRequest(request.Message);
            }).WithTags(EndpointConstants.IDARECI);



        }
    }
}
