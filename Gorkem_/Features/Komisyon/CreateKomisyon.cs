using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using Gorkem_.Migrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Komisyon
{
    public static class CreateKomisyon
    {
        public record Command(KomisyonEkleRequest Request) : IRequest<Result<int>>
        {

        }
        public class CreateKomisyonValidation : AbstractValidator<Command>
        {
            public CreateKomisyonValidation()
            {
                RuleFor(r=>r.Request.KomisyonAdi).NotEmpty().NotNull().WithMessage("Komisyon Adı boş bırakılamaz..");
                RuleFor(r => r.Request.OlusturulmaTarihi).NotEmpty().NotNull().WithMessage("Komisyon Oluşturulma Tarihi boş bırakılamaz..");
                RuleFor(r => r.Request.GorevYeriId).NotEmpty().NotNull().WithMessage("Komisyon Görev Yeri boş bırakılamaz");

            }
        }
        public static UT_Komisyon ToKomisyon(this Command command)
        {
            return new UT_Komisyon
            {
                KomisyonAdi = command.Request.KomisyonAdi,
                OlusturulmaTarihi = command.Request.OlusturulmaTarihi,
                GorevYeriId = command.Request.GorevYeriId,
                T_Aktif = DateTime.Now,
                Aktifmi =true,
                

            };

        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<int>>
        {
            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExist = Context.UT_Komisyons.Any(r=>r.Id ==request.Request.Id);
                if (isExist) return await Result<int>.FailAsync($"{request.Request.Id} is already exist");

                var komisyon = request.ToKomisyon();

                Context.UT_Komisyons.Add(komisyon);


                var isSaved = await Context.SaveChangesAsync()>0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} tarihinde eklendi", request.Request.KomisyonAdi, "DemoAccount", DateTime.Now);
                    return await Result<int>.SuccessAsync(komisyon.Id);
                }
                return await Result<int>.FailAsync("Kayıt başarılı değil.");
            }
        }
    }
    public class CreateKomisyonEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("komisyon/createKomisyon", async ([FromBody] KomisyonEkleRequest model, ISender sender) =>
            {
                var request = new CreateKomisyon.Command(model);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
