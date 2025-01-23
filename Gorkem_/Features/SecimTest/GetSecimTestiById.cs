using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.SecimTest;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.SecimTest
{
    public static class GetSecimTestiById
    {
        public class Query : IRequest<Result<KopekSecimTestiGetirResponse>>
        {
            public int Id { get; set; }
        }
        public class GetSecimTestiByIdValidation : AbstractValidator<Query>
        {
            public GetSecimTestiByIdValidation()
            {
                RuleFor(x => x.Id).GreaterThan(0).WithMessage("Secim Testi Id değeri 0dan büyük olmalıdır");
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Query, Result<KopekSecimTestiGetirResponse>>
        {

            public async Task<Result<KopekSecimTestiGetirResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var secimTest = await Context.UT_SecimTests
                    .Include(x=>x.Kopek)
                    .Include(x=>x.SecimTest)
                    .Include(x=>x.SinavYeri)
                    .Include(x=>x.Komisyon).FirstOrDefaultAsync(x=>x.Id == request.Id);


                if (secimTest == null)
                    return Result<KopekSecimTestiGetirResponse>.Fail("Seçim Testi Bulunamadı");

                var secimTestResponse = new KopekSecimTestiGetirResponse
                {
                    Degerlendirme=secimTest.Degerlendirme,
                    Havlama=secimTest.Havlama,
                    Komisyon=secimTest.Komisyon?.KomisyonAdi,
                    KomisyonId=secimTest.KomisyonId,
                    Kopek = secimTest.Kopek?.KopekAdi,
                    KopekId=secimTest.KopekId,
                    SecimTest = secimTest.SecimTest?.Name,
                    SecimTestBrans = secimTest.SecimTestBrans,
                    SecimTestId = secimTest.SecimTestId,
                    SinavYeri = secimTest.SinavYeri?.Name,
                    SinavYeriId= secimTest.SinavYeriId,
                    Tarih= secimTest.Tarih,
                    TepkiSekli=secimTest.TepkiSekli,
                    ToplamPuan=secimTest.ToplamPuan,
                    ProfileImage=secimTest.Kopek.ProfileImage
                    
                };

                return Result<KopekSecimTestiGetirResponse>.Success(secimTestResponse);
                    
            }
        }
    }

    public class GetSecimTestiByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("secimTesti/getSecimTestiById", async (int id, ISender sender) =>
            {
                var request = new GetSecimTestiById.Query { Id = id };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);


            }).WithTags(EndpointConstants.SECİMTEST);
        }
    }
}
