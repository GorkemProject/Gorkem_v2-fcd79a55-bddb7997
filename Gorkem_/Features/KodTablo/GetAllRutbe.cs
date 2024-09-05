﻿using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllRutbe
    {
        public class Query : IRequest<List<RutbeGetirResponse>>
        {
        }
        public class RutbeGetirValidation : AbstractValidator<Query>
        {
            public RutbeGetirValidation()
            {
                //listeleme işlemi yaptığım için validasyon yapmıyoruz.
            }
        }
        internal sealed class Handler : IRequestHandler<Query, List<RutbeGetirResponse>>
        {
            private readonly GorkemDbContext _context;
            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<List<RutbeGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifRutbeler = await _context.KT_Rutbes
                    .Where(b => b.Aktifmi)
                    .Select(b => new RutbeGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return aktifRutbeler;
            }
        }
    }
    public class GetAllRutbeEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/rutbe", async (ISender sender) =>
            {
                var request = new GetAllRutbe.Query();
                var response = await sender.Send(request);

                return Results.Ok(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }
}
