using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.Komisyon
{
    public class UpdateKomisyon
    {
        public class KomisyonCommand : IRequest<Result<bool>>
        {
            public int Id { get; set; }
            public string? KomisyonAdi { get; set; }
            public DateTime OlusturulmaTarihi { get; set; }
            public int GorevYeriId { get; set; }
        }
        public class KomisyonValidation : AbstractValidator<KomisyonCommand>
        {
            public KomisyonValidation()
            {
                RuleFor(r => r.KomisyonAdi).NotNull().NotEmpty().WithMessage("Komisyon adını boş bırakamazsınız..");
                RuleFor(r => r.OlusturulmaTarihi).NotNull().NotEmpty().WithMessage("Komisyon oluşturulma tarihini boş bırakamazsınız..");
                RuleFor(r => r.GorevYeriId).NotNull().NotEmpty().WithMessage("Komisyon görev yerini adını boş bırakamazsınız..");
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<KomisyonCommand, Result<bool>>
        {
            public async Task<Result<bool>> Handle(KomisyonCommand request, CancellationToken cancellationToken)
            {
                var komisyon = await Context.UT_Komisyons.FindAsync(request.Id);
                if (komisyon == null)
                {
                    return await Result<bool>.FailAsync("Komisyon bulunamadı..");
                };
                komisyon.KomisyonAdi=request.KomisyonAdi;
                komisyon.OlusturulmaTarihi=request.OlusturulmaTarihi;
                komisyon.GorevYeriId=request.GorevYeriId;

                var isSaved = await Context.SaveChangesAsync(cancellationToken) > 0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} tarafından Güncellendi.", request.KomisyonAdi, "DemoAccount", DateTime.Now);
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Komisyon Gücelleme Başarısız");
            }
        }
    }
    public class UpdateKomisyonEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("komisyon/{id}/updateKomisyon", async (int id, [FromBody] UpdateKomisyon.KomisyonCommand model, ISender send) =>
            {
                model.Id = id;
                var result = await send.Send(model);
                if (result.Succeeded)
                    return Results.Ok(result);
                return Results.BadRequest(result);

            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
