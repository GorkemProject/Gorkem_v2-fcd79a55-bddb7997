using AspNetCoreHero.Results;
using Carter;
using Gorkem_.Context;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Idareci
{
    public  class GetAllIdareci
    {

        public class Query : IRequest<Result<List<RealIdareciGetirResponse>>>
        {

        }

        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<RealIdareciGetirResponse>>>
        {
            public async Task<Result<List<RealIdareciGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifIdareciler = await Context.UT_Idarecis
                    .Where(a => a.Aktifmi)
                    .Include(r => r.Idareci)
                    .Select(a => new RealIdareciGetirResponse
                    {
                        Id = a.Idareci.Id,
                        AdSoyad = a.Idareci.AdSoyad,
                        CepTelefonu = a.Idareci.CepTelefonu,
                        DogumTarihi = a.Idareci.DogumTarihi,
                        Puan = a.Idareci.Puan
                    }).ToListAsync(cancellationToken);
                return Result<List<RealIdareciGetirResponse>>.Success(aktifIdareciler);
            }
        }
    }

    public class GetAllIdareciEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("idareci/GetAllIdareci", async (ISender sender) =>
            {
                var request =new GetAllIdareci.Query();
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.IDARECI);
        }
    }
}
