﻿using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetAllKursiyerByKursId
    {
        public class Query : IRequest<Result<List<KursIdyeGoreKursiyerGetirResponse>>>
        {
            public int KursId { get; set; }
            public Query(int kursId)
            {
                KursId = kursId;
            }
        }

        internal sealed class Handler : IRequestHandler<Query, Result<List<KursIdyeGoreKursiyerGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KursIdyeGoreKursiyerGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var kursiyerler = await _context.UT_Kurs
                    .Where(k => k.Id == request.KursId && k.Aktifmi)
                    .Include(e => e.Kursiyerler)

                    .SelectMany(k => k.Kursiyerler
                        .Where(e => e.Aktifmi)
                        .Select(e => new KursIdyeGoreKursiyerGetirResponse
                        {
                            Id = e.Id,
                            Sicil = e.Sicil,
                            PersonelAdi = e.PersonelAdi,
                            KopekId = e.KopekId,
                            CipNumarası = e.CipNumarası,
                            KopekName = e.Kopek.KopekAdi,
                            KursAdi = e.Kurs.KursEgitimListesi.Name,
                            KursDonem = e.Kurs.Donem,


                        }))
                    .ToListAsync(cancellationToken);

                if (kursiyerler == null)
                {
                    return Result<List<KursIdyeGoreKursiyerGetirResponse>>.Fail("Bu kursa ait kursiyer bulunamadı.");
                }

                return Result<List<KursIdyeGoreKursiyerGetirResponse>>.Success(kursiyerler);
            }
        }
    }

    public class GetAllKursiyerByKursIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet = app.MapGet("kopekKurs/GetAllKursiyerByKursId", async (int kursId, ISender sender) =>
             {
                 var request = new GetAllKursiyerByKursId.Query(kursId);
                 var response = await sender.Send(request);

                 if (response.Succeeded)
                     return Results.Ok(response);
                 return Results.BadRequest(response);
             }).WithTags(EndpointConstants.KOPEKKURS);
            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
