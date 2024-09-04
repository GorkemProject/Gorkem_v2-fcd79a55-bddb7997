﻿using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllCins
    {
        public class Query : IRequest<List<CinsGetirResponse>>
        {
        }
        public class BirimGetirValidation : AbstractValidator<Query>
        {
            public BirimGetirValidation()
            {
                //Listeleme işlemi yaptığımız için herhangi bir validasyon yapmadım. 
            }
        }
        internal sealed class Handler : IRequestHandler<Query, List<CinsGetirResponse>>
        {
            public readonly GorkemDbContext _context;
            public Handler(GorkemDbContext context)
            {
                _context = context;
            }
            public async Task<List<CinsGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifCinsler = await _context.KT_Cinss
                    .Where(b => b.Aktifmi)
                    .Select(b => new CinsGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                    }).ToListAsync(cancellationToken);
                return aktifCinsler;

                    
            }
        }
    }
    public class GetAllCinsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kodtablo/cins", async (ISender sender) =>
            {
                var request = new GetAllCins.Query();
                var response = await sender.Send(request);
                return Results.Ok(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }

}