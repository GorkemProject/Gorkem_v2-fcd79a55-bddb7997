using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Komisyon
{
    public static class GetKomisyonById
    {
        public class Query : IRequest<Result<KomisyonGetirResponse>>
        {
            public int Id { get; set; }
        }
        public class KomisyonByIdValidation : AbstractValidator<Query>
        {
            public KomisyonByIdValidation()
            {
                RuleFor(x => x.Id).GreaterThan(0).WithMessage("Komisyon Id 0'dan büyük olmalıdır.");
            }
        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<KomisyonGetirResponse>>
        {
            public async Task<Result<KomisyonGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var komisyon = await Context.UT_Komisyons
                    .Where(a=>a.Aktifmi && a.Id == request.Id)
                    .Select(a=> new KomisyonGetirResponse
                    {
                        Id = a.Id,
                        KomisyonAdi = a.KomisyonAdi,
                        GorevYeriId = a.GorevYeriId,
                        OlusturulmaTarihi = a.OlusturulmaTarihi,
                        
                        
                    }).FirstOrDefaultAsync(cancellationToken);
                if (komisyon == null)
                {
                    return Result<KomisyonGetirResponse>.Fail("Komisyon bulunamadı");

                }
                return Result<KomisyonGetirResponse>.Success(komisyon);
            }
        }
    }

    public class GetKomisyonByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("komisyon/{id}", async (int id, ISender sender) =>
            {
                var request = new GetKomisyonById.Query { Id = id };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOMISYON); 
        }
    }
}
