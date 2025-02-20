﻿using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KodTablo
{
    public static class GetAllKursiyerDegerlendirmeSorular
    {

        public class Query : IRequest<Result<List<KursiyerDegerlendirmeSorularGetirResponse>>>;

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<KursiyerDegerlendirmeSorularGetirResponse>>>
        {
            public async Task<Result<List<KursiyerDegerlendirmeSorularGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                //var aktifSorular = await Context.KT_KursKursiyerDegerlendirmeSorular
                //    .Where(b => b.Aktifmi)
                //    .Select(b => new KursiyerDegerlendirmeSorularGetirResponse
                //    {
                //        Id = b.Id,
                //        Name = b.Name
                //    }).ToListAsync(cancellationToken);

                var kursiyerSorular = await Context.KT_KursDegerlendirmeSorular
                    .Where(b => b.Aktifmi && b.DegerlendirmeTuru == 2)
                    .Select(b => new KursiyerDegerlendirmeSorularGetirResponse
                    {
                        Id = b.Id,
                        Name = b.Name,
                        MaxPuan = b.MaxPuan
                    }).ToListAsync(cancellationToken);
                    

                return Result<List<KursiyerDegerlendirmeSorularGetirResponse>>.Success(kursiyerSorular);
            }
        }
    }

    public class GetAllKursiyerDegerlendirmeSorularEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapGet("kodtablo/GetAllKursiyerDegerlendirmeSorular", async (ISender sender) =>
            {
                var request = new GetAllKursiyerDegerlendirmeSorular.Query();
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
