using System;
using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Idareci;

public record GetIdareciBySicilQuery(int Sicil) : IRequest<Result<IdareciGetirResponse>>;

public class GetIdareciBySicilQueryHandler : IRequestHandler<GetIdareciBySicilQuery, Result<IdareciGetirResponse>>
{
    private readonly GorkemDbContext context;

    public GetIdareciBySicilQueryHandler(GorkemDbContext context)
    {
        this.context = context;
    }

    public async Task<Result<IdareciGetirResponse>> Handle(GetIdareciBySicilQuery request, CancellationToken cancellationToken)
    {
        var idareci = await context.UT_AdayIdareci.FirstOrDefaultAsync(x=>x.Sicil.Equals(request.Sicil));
        if(idareci is null)
            return await Result<IdareciGetirResponse>.FailAsync("Idareci bulunamadı");

        return await Result<IdareciGetirResponse>.SuccessAsync(idareci.Adapt<IdareciGetirResponse>());
    }
}

public class GetIdareciBySicilEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var mapGet=app.MapGet("idareci/getIdareciBySicil", async (int sicil, ISender sender) =>
        {
            var response = await sender.Send(new GetIdareciBySicilQuery(sicil));
            if (response.Succeeded)
                return Results.Ok(response);

            return Results.BadRequest(response.Message);
        }).WithTags(EndpointConstants.IDARECI);

        if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
        {
            mapGet.RequireAuthorization();
        }
    }
}