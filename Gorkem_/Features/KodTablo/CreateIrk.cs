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
    public static class CreateIrk
    {
        public class Command : IRequest<Result<bool>>
        {
            public string Name { get; set; }
        }
        private class CreateIrkValidation : AbstractValidator<Command>
        {
            public CreateIrkValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "Ad Boş Olamaz");
            }
        }
        public static KT_Irk ToIrk(this Command command)
        {
            return new KT_Irk
            {
                Name = command.Name,
                Aktifmi = true,
                T_Aktif = DateTime.Now
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
                var isExists = _context.KT_Irks.Any(r => r.Name == request.Name);
                if (isExists) return await Result<bool>.FailAsync($"{request.Name} is already exist");

                _context.KT_Irks.Add(request.ToIrk());
                var isSaved = await _context.SaveChangesAsync() > 0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Kayıt Başarılı Değil");

            }
        }
    }
    public class CreateIrkEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kodtablo/irk", async ([FromBody] IrkEkleRequest model, ISender sender) =>
            {
                var request = new CreateIrk.Command() { Name = model.IrkAdi };
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok();
                return Results.BadRequest(response.Message);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
