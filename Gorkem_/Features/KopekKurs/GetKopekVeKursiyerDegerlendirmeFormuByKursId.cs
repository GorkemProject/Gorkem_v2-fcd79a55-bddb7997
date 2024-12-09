using System.Drawing.Text;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.KopekKurs
{
    public static class GetKopekVeKursiyerDegerlendirmeFormuByKursId
    {

        public class Query : IRequest<Result<List<KursiyerKopekDegerlendirmeResponse>>>
        {
            public int KursId { get; set; }

            public Query(int kursId)
            {
                KursId = kursId;
            }
        }

        

        internal sealed class Handler : IRequestHandler <Query, Result<List<KursiyerKopekDegerlendirmeResponse>>>
        {
            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<KursiyerKopekDegerlendirmeResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                ////Form ve detaylarını çektik
                //var degerlendirmeler = await _context.UT_KopekVeIdareciDegerlendirmeFormu
                //     .Include(f => f.KursDegerlendirmeCevaplar)
                //         .ThenInclude(c=>c.DegerlendirilenVarlikId)
                //         //.ThenInclude(c => c.DegerlendirmeSoru)
                //     .Where(f => f.KursId == request.KursId)
                //     .ToListAsync(cancellationToken);
                ////Sonuçları alıyoruz

                //var response = degerlendirmeler.Select(form => new KursiyerKopekDegerlendirmeResponse
                //{
                //    PersonelSicil = form.KursDegerlendirmeCevaplar.Select(a => a.DegerlendirilenVarlikId).FirstOrDefault(),
                //    PersonelAdi=form.KursDegerlendirmeCevaplar.Select(a=>a.)
                //});
                return null;
            }
        }
    }

    public class GetKopekVeKursiyerDegerlendirmeFormuByKursIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/GetKopekVeKursiyerDegerlendirmeFormuByKursId", async (int kursId, ISender sender) =>
            {
                var request = new GetKopekVeKursiyerDegerlendirmeFormuByKursId.Query(kursId);
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
