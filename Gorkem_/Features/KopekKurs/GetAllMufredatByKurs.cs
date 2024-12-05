using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetAllMufredatByKurs
    {
        public class Query : IRequest<Result<List<KursunMufredatlariniGetirResponse>>>
        {

            public int KursId { get; set; }

            public Query(int kursId)
            {
                KursId = kursId;
            }

        }
        internal sealed class Handler : IRequestHandler<Query, Result<List<KursunMufredatlariniGetirResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KursunMufredatlariniGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var kurs = await _context.UT_Kurs.FindAsync(request.KursId);

                var mufredatlar = await _context.KT_KursMufredats
                    .Include(k=>k.KursEgitimListesi)
                    .Where(u => u.KursEgitimListesiId == kurs.KursEgitimListesiId)
                    .Select(k => new KursunMufredatlariniGetirResponse
                    {
                        Id=k.Id,
                        KursAdi= k.KursEgitimListesi.Name,
                        MufredatAdi = k.Name,
                        OlusturulmaTarihi = k.T_Aktif
                    }).ToListAsync(cancellationToken);
            
                if (mufredatlar == null || !mufredatlar.Any())
                {
                    return Result<List<KursunMufredatlariniGetirResponse>>.Fail("Kursa ait bir müfredat bulunamadı..");
                } 
                return Result<List<KursunMufredatlariniGetirResponse>>.Success(mufredatlar);
            }

            
        }
    }

    public class GetAllMufredatByKursEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kopekKurs/GetMufredatByKursId", async (int kursId, ISender sender) =>
            {
                var request = new GetAllMufredatByKurs.Query(kursId);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);


            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
