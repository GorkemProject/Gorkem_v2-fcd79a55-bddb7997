using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Contracts.Kopek
{
    public static class ListAllKopekFilter
    {

        public record Query(KopekListeleRequest Request) : IRequest<Result<KopekPaginationResponse>>;

        internal sealed class Handler : IRequestHandler<Query, Result<KopekPaginationResponse>>
        {

            private readonly GorkemDbContext _context;

            public Handler(GorkemDbContext context)
            {
                _context = context;
            }

            public async Task<Result<KopekPaginationResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.UT_Kopek_Kopeks
                    .Include(a => a.Irk)
                    .Include(a => a.Birim)
                    .AsQueryable();

                // Irka göre filtreleme
                if (request.Request.IrkId != 0)
                {
                    query = query.Where(x => x.IrkId == request.Request.IrkId);
                }
                // KadroIle göre filtreleme
                if (request.Request.KadroIlId != 0)
                {
                    query = query.Where(x => x.KadroIlId == request.Request.KadroIlId);
                }
                // Karara göre filtreleme
                if (request.Request.KararId != 0)
                {
                    query = query.Where(x => x.KararId == request.Request.KararId);
                }
                // Cinsiyete göre filtreleme
                if (request.Request.Cinsiyet != 0)
                {
                    query = query.Where(x => x.Cinsiyet == request.Request.Cinsiyet);
                }
                // Edinim şekline göre filtreleme
                if (request.Request.EdinimSekli != 0)
                {
                    query = query.Where(x => x.EdinimSekli == request.Request.EdinimSekli);
                }
                // Köpek Duruma göre filtreleme
                if (request.Request.KopekDurum != 0)
                {
                    query = query.Where(x => x.KopekDurum == request.Request.KopekDurum);
                }
                // Birime göre filtreleme
                if (request.Request.BirimId != 0)
                {
                    query = query.Where(x => x.BirimId == request.Request.BirimId);
                }
                // Kuvve Numarasına göre filtreleme

                if (request.Request.KuvveNumarasiAltSinir != 0 && request.Request.KuvveNumarasiUstSinir != 0)
                {
                    query = query.Where(x => Convert.ToInt64(x.KuvveNumarasi) >= request.Request.KuvveNumarasiAltSinir && Convert.ToInt64(x.KuvveNumarasi) <= request.Request.KuvveNumarasiUstSinir);
                }
                // Çip numarasına göre filtreleme

                if (request.Request.CipNumarasiAltSinir != 0 && request.Request.CipNumarasiUstSinir !=0)
                {
                    query = query.Where(x => Convert.ToInt64(x.CipNumarasi) >= request.Request.KuvveNumarasiAltSinir && Convert.ToInt64(x.CipNumarasi) <= request.Request.KuvveNumarasiUstSinir);
                }
                // Doğum tarihine göre filtreleme
                if (request.Request.DogumTarihiBaslangic != null && request.Request.DogumTarihiBitis != null)
                {
                    query = query.Where(x => x.T_Aktif >= request.Request.DogumTarihiBaslangic && x.T_Aktif <= request.Request.DogumTarihiBitis);
                }

                // Sıralama işlemi
                if (!string.IsNullOrEmpty(request.Request.SortBy))
                {
                    var sortBy = request.Request.SortBy.ToLower();
                    if (sortBy == "Irk")
                    {
                        query = request.Request.IsAscending ? query.OrderBy(x => x.Irk) : query.OrderByDescending(x => x.Irk);
                    }
                    if (sortBy == "Kadro")
                    {
                        query = request.Request.IsAscending ? query.OrderBy(x => x.KadroIl) : query.OrderByDescending(x => x.KadroIl);
                    }
                    if (sortBy == "Karar")
                    {
                        query = request.Request.IsAscending ? query.OrderBy(x => x.Karar) : query.OrderByDescending(x => x.Karar);
                    }
                    if (sortBy == "Cinsiyet")
                    {
                        query = request.Request.IsAscending ? query.OrderBy(x => x.Cinsiyet) : query.OrderByDescending(x => x.Cinsiyet);
                    }

                    if (sortBy == "KuvveNumarasi")
                    {
                        query = request.Request.IsAscending ? query.OrderBy(x => x.KuvveNumarasi) : query.OrderByDescending(x => x.KuvveNumarasi);
                    }
                    if (sortBy == "CipNumarasi")
                    {
                        query = request.Request.IsAscending ? query.OrderBy(x => x.CipNumarasi) : query.OrderByDescending(x => x.CipNumarasi);
                    }
                }

                // Sayfa verilerini al
                var totalCount = await query.CountAsync(cancellationToken);
                var kopekler = await query
                    .Skip((request.Request.PageNumber - 1) * request.Request.PageSize)
                    .Take(request.Request.PageSize)
                    .Select(x => new KopekListeleResponse
                    {
                        KopekAdi=x.KopekAdi,
                        BirimId = x.BirimId,
                        Cinsiyet = x.Cinsiyet,
                        CipNumarasi = x.CipNumarasi,
                        EdinimSekli = x.EdinimSekli,
                        IrkId = x.IrkId,
                        KadroIlId = x.KadroIlId,
                        KararId = x.KararId,
                        KopekDurum = x.KopekDurum,
                        KuvveNumarasi = x.KuvveNumarasi,
                        T_Aktif = x.T_Aktif

                    }).ToListAsync(cancellationToken);

                var response = new KopekPaginationResponse
                {
                    TotalCount = totalCount,
                    PageNumber = request.Request.PageNumber,
                    PageSize = request.Request.PageSize,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)request.Request.PageSize),
                    Kopekler = kopekler
                };

                return Result<KopekPaginationResponse>.Success(response);
            }

        }
    }

    public class ListAllKopekFilterEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopek/ListAllKopekFilter", async ([FromBody] KopekListeleRequest model, ISender sender) =>
            {
                var query = new ListAllKopekFilter.Query(model);
                var response = await sender.Send(query);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.KOPEK);
        }
    }
}
