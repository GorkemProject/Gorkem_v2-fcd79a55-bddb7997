using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Gorkem_.Features.UygulamaTablo.KodTablo
{
    public static class CreateKopekTuru
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Name { get; set; }
        }
        public class CreateKopekTuruValidation : AbstractValidator<Command>
        {
            public CreateKopekTuruValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "Ad Boş Olamaz");
            }
        }
        public static KT_KopekTuru ToKopekTuru(this Command command)
        {
            return new KT_KopekTuru
            {
                Name = command.Name,
                Aktifmi = true,
                T_Aktif = DateTime.Now,
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
                var isExists = _context.KT_KopekTurus.Any(r => r.Name == request.Name);
                if (isExists) return await Result<bool>.FailAsync($"{request.Name} is already exist");
                _context.KT_KopekTurus.Add(request.ToKopekTuru());
                var isSaved = await _context.SaveChangesAsync() > 0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Kayıt Başarılı Değil.");

            }
        }
    }
    public class CreateKopekTuruEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kodtablo/kopekturu", async ([FromBody] KopekTuruEkleRequest model, ISender sender) =>
            {
                var request = new CreateKopekTuru.Command() { Name = model.KopekTuruAdi };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok();
                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
