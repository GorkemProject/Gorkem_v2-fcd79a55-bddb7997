using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using Gorkem_.Features.Kopek;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Idareci
{
    public class GetAllAdayIdareci
    {
        public class Query : IRequest<Result<List<IdareciGetirResponse>>>
        {

        }
        public class IdareciGetirValidation : AbstractValidator<Query>
        {
            public IdareciGetirValidation()
            {
                //listeleme işlemi olduğu için validasyon yapmaıdm

            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<List<IdareciGetirResponse>>>
        {

            public async Task<Result<List<IdareciGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aktifIdareciler = await Context.UT_AdayIdareci
                    
                    .Where(a => a.Aktifmi)
                    .Select(a => new IdareciGetirResponse
                    {
                        Id = a.Id,
                        Sicil = a.Sicil,
                        AdSoyad = a.AdSoyad,
                        CepTelefonu = a.CepTelefonu,
                        DogumTarihi = a.DogumTarihi,
                        IdareciDurumId = a.IdareciDurumId,
                        GorevYeriId = a.GorevYeriId,
                        BransId = a.BransId,
                        RutbeId = a.RutbeId,
                        AskerlikId = a.AskerlikId
                        
                    }).ToListAsync(cancellationToken);
                return Result<List<IdareciGetirResponse>>.Success(aktifIdareciler);
            }
        }
    }
    public class GetAllAdayIdareciEndpoint: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapGet("idareci/getAllAdayIdareci", async (ISender sender) =>
            {
                var request = new GetAllAdayIdareci.Query();
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.IDARECI);
            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }

       
    }
}
