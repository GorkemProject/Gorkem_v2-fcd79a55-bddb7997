using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.KodTablo
{
    public static class CreateBrans
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Name { get; set; }

        }
        public class CreateBransValidation : AbstractValidator<Command>
        {
            public CreateBransValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "Ad Boş Olamaz");
            }
        }
        public static KT_Brans ToBrans(this Command command)
        {
            return new KT_Brans
            {
                Name = command.Name,
                Aktifmi = true,
                T_Aktif = DateTime.UtcNow
            };
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
                var isExists = _context.Branss.Any(r => r.Name == request.Name);
                if (isExists) return await Result<bool>.FailAsync($"{request.Name} is already exist");

                _context.Branss.Add(request.ToBrans());
                var isSaved = await _context.SaveChangesAsync()>0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Kayıt Başarılı Değil");
            }
        }
    }
    public class CreateBransEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kodtablo/brans", async ([FromBody] BransEkleRequest model, ISender sender) =>
            {
                var request = new CreateBrans.Command() { Name = model.BransAdi };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok();
                return Results.BadRequest(response.Message);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
