using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Komisyon;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Komisyon
{
    public class GetUyelerByKomisyonId
    {
        public record Query(int KomisyonId) : IRequest<Result<List<KomisyonUyeleriListeleResponse>>>
        {
        }

        public class GetUyelerByKomisyonIdValidation : AbstractValidator<Query>
        {
            public GetUyelerByKomisyonIdValidation()
            {
                RuleFor(r=>r.KomisyonId).GreaterThan(0).WithMessage("Üyelerini görmek istediğin komisyonu seçmelisin");
            }
        }



        public class Handler : IRequestHandler<Query, Result<List<KomisyonUyeleriListeleResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KomisyonUyeleriListeleResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var komisyon = await _context.UT_Komisyons
                    .Include(k => k.KomisyonUyeleri)
                    .FirstOrDefaultAsync(k => k.Id == request.KomisyonId);

                if (komisyon == null)
                    return await Result<List<KomisyonUyeleriListeleResponse>>.FailAsync("Komisyon bulunamdı");

                if(komisyon.KomisyonUyeleri == null || !komisyon.KomisyonUyeleri.Any())
                    return await Result<List<KomisyonUyeleriListeleResponse>>.FailAsync("Bu komisyonda üye bulunamadı.");

                var uyeler = komisyon.KomisyonUyeleri.Select(u => new KomisyonUyeleriListeleResponse
                {
                    Id= u.Id,
                    AdSoyad = u.AdSoyad,
                    TcKimlikNo = u.TcKimlikNo,
                    CepTelefonu = u.CepTelefonu,
                    Eposta = u.Eposta,
                    GorevUnvani = u.GorevUnvani,
                    GorevYeri = u.GorevYeri,
                    Sicil = u.Sicil
                }).ToList();

                return await Result<List<KomisyonUyeleriListeleResponse>>.SuccessAsync(uyeler);
            }
        }
    }
    public class GetUyelerByKomisyonIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("komisyon/{komisyonId}/getKomisyonUyeleri", async (int komisyonId, ISender sender) =>
            {
                var query = new GetUyelerByKomisyonId.Query(komisyonId);
                var response = await sender.Send(query);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOMISYON);
        }
    }
}
