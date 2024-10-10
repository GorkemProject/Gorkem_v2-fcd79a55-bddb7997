using System;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.EndpointTags;
using Gorkem_.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Kopek;

public record KopekCinsiyetResponse(int Id, string Name, string CipNumarasi);
public record GetAllKopekByCinsiyetQuery(DateTime DogumTarihi) : IRequest<Result<Dictionary<string,List<KopekCinsiyetResponse>>>>;

public class GetAllKopekByCinsiyetQueryHandler : IRequestHandler<GetAllKopekByCinsiyetQuery, Result<Dictionary<string,List<KopekCinsiyetResponse>>>>
{
    private readonly GorkemDbContext context;

    public GetAllKopekByCinsiyetQueryHandler(GorkemDbContext context)
    {
        this.context = context;
    }

    public async Task<Result<Dictionary<string,List<KopekCinsiyetResponse>>>> Handle(GetAllKopekByCinsiyetQuery request, CancellationToken cancellationToken)
    {
        var query = context.UT_Kopek_Kopeks.AsQueryable();
        var kopekList = new Dictionary<string,List<KopekCinsiyetResponse>>();

        var disiKopekler = await query
        .Where(x=>x.Cinsiyet.Equals(Enum_Cinsiyet.Disi) && x.DogumTarihi < request.DogumTarihi)
        .Select(x=> new KopekCinsiyetResponse(x.Id,x.KopekAdi,x.CipNumarasi))
        .ToListAsync();

        var ErkekKopekler = await query
        .Where(x=>x.Cinsiyet.Equals(Enum_Cinsiyet.Erkek) && x.DogumTarihi < request.DogumTarihi)
        .Select(x=> new KopekCinsiyetResponse(x.Id,x.KopekAdi,x.CipNumarasi))
        .ToListAsync();

        kopekList.Add("disi", disiKopekler);
        kopekList.Add("erkek", ErkekKopekler);

        return await Result<Dictionary<string, List<KopekCinsiyetResponse>>>.SuccessAsync(kopekList);
    
    }
}

public class KopekFilterByCinsiyetEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("kopek/kopekFilterByCinsiyet", async (DateTime dogumTarihi, ISender sender) =>
            {
                var response = await sender.Send(new GetAllKopekByCinsiyetQuery(dogumTarihi));

                if (response.Succeeded)
                    return Results.Ok(response);

                return Results.BadRequest(response.Message);

            }).WithTags(EndpointConstants.KOPEK);
        }
    }
