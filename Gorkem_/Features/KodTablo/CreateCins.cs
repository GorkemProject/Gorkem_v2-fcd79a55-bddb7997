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
    public static class CreateCins
    {
        public class Command : IRequest<Result<bool>>
        {
            //Parametreler
            public string Name { get; set; }
        }
        public class CreateCinsValidation : AbstractValidator<Command>
        {
            public CreateCinsValidation()
            {
                RuleFor(r=>r.Name).NotEmpty().NotNull().Configure(r=>r.MessageBuilder =_=>"Ad Kısmı Boş Olamaz");
            }
        }
        public static KT_Cins ToCins(this Command command)
        {
            return new KT_Cins
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
                var newCins = _context.KT_Cinss.Any(r => r.Name == request.Name);
                if (newCins) return await Result<bool>.FailAsync($"{request.Name} is already exists");

                _context.KT_Cinss.Add(request.ToCins());
                var isSaved = await _context.SaveChangesAsync() > 0;
                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);

                return await Result<bool>.FailAsync("Kayıt Başarılı Değil.");
               
            }
        }
    }
    public class CreateCinsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kodtablo/cins", async ([FromBody] CinsEkleRequest model, ISender sender) =>
            {
                var request = new CreateCins.Command() { Name = model.CinsAdi };
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok();
                return Results.BadRequest(response.Message);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
