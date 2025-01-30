using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Idareci
{
    public static class ListKopekFromIdareci
    {
        public record Query(IdareciKopekListeleRequest Request) : IRequest<Result<List<KopekIdareciResponse>>> { }

        internal sealed class Handler : IRequestHandler<Query, Result<List<KopekIdareciResponse>>>
        {
            private readonly GorkemDbContext _context;
            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KopekIdareciResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var kopekler = _context.UT_Kopek_Kopeks.AsQueryable();
                var idareciKopekleri = _context.UT_IdareciKopekleri.Where(r => r.Aktifmi == request.Request.Aktifmi).AsQueryable();
                var idareciler = _context.UT_AdayIdareci.AsQueryable();

                if (request.Request.IdareciId.HasValue)
                {
                    idareciKopekleri = idareciKopekleri.Where(r => r.AdayIdareciId == request.Request.IdareciId);
                }

                if (request.Request.KopekId.HasValue)
                {
                    idareciKopekleri = idareciKopekleri.Where(r => r.KopekId == request.Request.KopekId);
                }

                var query = await (from kopek in kopekler
                                 join idareciKopek in idareciKopekleri on kopek.Id equals idareciKopek.KopekId
                                 join idareci in idareciler on idareciKopek.AdayIdareciId equals idareci.Id
                                 select new KopekIdareciResponse
                                 {
                                     IdareciId = idareciKopek.AdayIdareciId,
                                     AdSoyad = idareci.AdSoyad,
                                     KopekAdi = kopek.KopekAdi,
                                     Sicil = idareci.Sicil,
                                     KopekCipNumarasi = kopek.CipNumarasi,
                                     KopekKuvveNumarasi = kopek.KuvveNumarasi,
                                     KopekId = kopek.Id
                                 }).ToListAsync(cancellationToken);

                return await Result<List<KopekIdareciResponse>>.SuccessAsync(query);
            }
        }
    }

    public class ListKopekFromIdareciEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapGet("idareci/getIdarecisKopek", async ([FromQuery] int? idareciId, [FromQuery] int? kopekId, [FromQuery] bool aktifmi, ISender sender) =>
            {
                var request = new IdareciKopekListeleRequest { IdareciId = idareciId, KopekId = kopekId, Aktifmi = aktifmi };
                var response = await sender.Send(new ListKopekFromIdareci.Query(request));
                if (response.Succeeded)
                    return Results.Ok(response.Data);

                return Results.BadRequest(response.Message);
            }).WithTags(EndpointConstants.IDARECI);
            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
