using System;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Kopek;
using Gorkem_.EndpointTags;
using Mapster;
using MediatR;

namespace Gorkem_.Features.Kopek;

public record GetKopekByIdOrCipQuery(int? Id, string? CipNo) : IRequest<Result<KopekGetirResponse>>;

public class GetKopekByIdOrCipQueryHandler : IRequestHandler<GetKopekByIdOrCipQuery, Result<KopekGetirResponse>>
{
    private readonly GorkemDbContext context;
    public GetKopekByIdOrCipQueryHandler(GorkemDbContext context)
    {
        this.context = context;
    }

    public async Task<Result<KopekGetirResponse>> Handle(GetKopekByIdOrCipQuery request, CancellationToken cancellationToken)
    {
        var kopek = context.UT_Kopek_Kopeks.Where(x=>x.Id == request.Id || x.CipNumarasi == request.CipNo).FirstOrDefault();
        if(kopek is null)
        {
            return await Result<KopekGetirResponse>.FailAsync("Kopek bulunamadı");
        }

        return await Result<KopekGetirResponse>.SuccessAsync(kopek.Adapt<KopekGetirResponse>());
    }
}

public class GetKopekByIdOrCipEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("kopek/getKopekByIdOrCip", async (int? id, string? cipNo, ISender sender) =>
        {
            var response = await sender.Send(new GetKopekByIdOrCipQuery(id,cipNo));
            if (response.Succeeded)
                return Results.Ok(response);

            return Results.BadRequest(response.Message);
        }).WithTags(EndpointConstants.KOPEK);
    }
}