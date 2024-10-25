using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Idareci;
using Gorkem_.EndpointTags;
using Gorkem_.Features.Kopek;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Idareci
{
    public class GetAllIdareci
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
                var aktifIdareciler = await Context.UT_Idarecis
                    .Where(a => a.Aktifmi)
                    .Select(a => new IdareciGetirResponse
                    {
                        Sicil = a.Sicil,
                        AdSoyad = a.AdSoyad,
                        CepTelefonu = a.CepTelefonu,
                        DogumTarihi = a.DogumTarihi,
                        IdareciDurumId = a.IdareciDurumId,
                        KadroIlId = a.KadroIlId,
                        BransId = a.BransId,
                        RutbeId = a.RutbeId,
                        AskerlikId = a.AskerlikId
                        
                    }).ToListAsync(cancellationToken);
                return Result<List<IdareciGetirResponse>>.Success(aktifIdareciler);
            }
        }
    }
    public class GetAllIdareciEndpoint: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("idareci/getAllIdareci", async (ISender sender) =>
            {
                var request = new GetAllIdareci.Query();
                var response = await sender.Send(request);
                return Results.Ok(response);
            }).WithTags(EndpointConstants.IDARECI);
        }

       
    }
}
