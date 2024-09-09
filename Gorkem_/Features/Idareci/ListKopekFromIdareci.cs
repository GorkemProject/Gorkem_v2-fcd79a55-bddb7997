using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Idareci
{
    public static class ListKopekFromIdareci
    {
        public record Query (IdareciKopekListeleRequest Request) : IRequest<Result<List<KopekIdareciResponse>>> { }

        internal sealed class Handler : IRequestHandler<Query, Result<List<KopekIdareciResponse>>>
        {
            private readonly GorkemDbContext _context;
            public Handler(GorkemDbContext context)
            {
                _context = context;
            }


            public async Task<Result<List<KopekIdareciResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {

                
                var query = from kopek in _context.UT_Kopek_Kopeks
                            join idareciKopek in _context.UT_IdareciKopekleri on kopek.Id equals idareciKopek.KopekId 
                            join idareci in _context.UT_Idarecis on idareciKopek.IdareciId equals idareci.Id
                            select new
                            {
                                IdareciKopek = idareciKopek,
                                Kopek = kopek,
                                Idareci = idareci
                            };

               
                if (request.Request.Aktifmi.HasValue)
                {
                    // bu kısımı böyle bıraktım çünkü sildiğimde false olan sonuçları göstermiyor
                    query = query.Where(x => x.IdareciKopek.Aktifmi == request.Request.Aktifmi.Value);
                }

                
                var result = await query.Select(x => new KopekIdareciResponse
                {
                    IdareciId = x.Idareci.Id,
                    KopekKuvveNumarasi = x.Kopek.KuvveNumarasi,
                    KopekCipNumarasi = x.Kopek.CipNumarasi
                }).ToListAsync(cancellationToken);

                return await Result<List<KopekIdareciResponse>>.SuccessAsync(result);

            }
        }
    }
    public class ListKopekFromIdareciEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("idarecikopek", async ([FromQuery] bool? aktifmi, ISender sender) =>
            {
                var request = new IdareciKopekListeleRequest { Aktifmi = aktifmi };
                var response = await sender.Send(new ListKopekFromIdareci.Query(request));
                if (response.Succeeded)
                    return Results.Ok(response.Data);


                return Results.BadRequest(response.Message);
            }).WithTags(EndpointConstants.IDARECI);
        }
    }
}
