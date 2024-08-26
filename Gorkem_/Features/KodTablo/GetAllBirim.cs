using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Gorkem_.Features.KodTablo
{
    public class GetAllBirim
    {
        public class Query : IRequest<Result<List<KT_Birim>>>
        {
            public bool? Aktifmi { get; set; }
            public string Name { get; set; }
        }

        public class BirimGetirValidation : AbstractValidator<Query>
        {
            public BirimGetirValidation()
            {
                RuleFor(x => x.Aktifmi)
                .Must(aktifMi => aktifMi == true)
                .WithMessage("Nesne aktif olmalıdır.");
            }
        }
        internal sealed class Handler : IRequestHandler<GetAllBirim.Query, Result<List<KT_Birim>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KT_Birim>>> Handle(GetAllBirim.Query request, CancellationToken cancellationToken)
            {
                var activeBirimler = await _context.Birims
                    .Where(r => r.Aktifmi == request.Aktifmi)
                    .ToListAsync();

                if (activeBirimler.Count == 0)
                    return await Result<List<KT_Birim>>.FailAsync("Aktif bir birim bulunamadı.");

                return await Result<List<KT_Birim>>.SuccessAsync(activeBirimler);
            }
        }
    }
    public class GetAllBirimEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/birim", async ([FromQuery] bool? aktifMi, ISender sender) =>
            {
                var request = new GetAllBirim.Query() { Aktifmi = aktifMi };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response.Data); // Dönen veriyi response.Data ile döndür

                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.KODTABLO);
        }
    }


}
