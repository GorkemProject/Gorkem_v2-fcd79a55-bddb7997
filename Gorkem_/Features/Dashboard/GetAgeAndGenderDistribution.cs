//using AspNetCoreHero.Results;
//using Carter;
//using Gorkem_.Context;
//using Gorkem_.Contracts.Dashboard;
//using Gorkem_.EndpointTags;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace Gorkem_.Features.Dashboard
//{
//    public static class GetAgeAndGenderDistribution
//    {

//        public class Query : IRequest<Result<List<YasVeCinsiyeteGoreKopekSayisiGetirResponse>>> { }

//        public class Handler(GorkemDbContext Context) : IRequestHandler<Query, Result<List<YasVeCinsiyeteGoreKopekSayisiGetirResponse>>>
//        {
//            public async Task<Result<List<YasVeCinsiyeteGoreKopekSayisiGetirResponse>>> Handle(Query request, CancellationToken cancellationToken)
//            {
               
//                var result= await Context.UT_Kopek_Kopeks
//                    .Select(k=> new 
//                    {
//                        Yas = EF.Functions.DateDiffYear(k.DogumTarihi, DateTime.Now),
//                        Cinsiyet= k.Cinsiyet,

//                    })
//                    .GroupBy(k =>
//                     k.Yas <= 1 ? "0-1 yaş" :
//                        k.Yas <= 2 ? "1-2 yaş" :
//                        k.Yas <= 3 ? "2-3 yaş" :
//                        k.Yas <= 4 ? "3-4 yaş" :
//                        k.Yas <= 5 ? "4-5 yaş" : "5+ yaş"
//                    )
//                    .Select(g => new YasVeCinsiyeteGoreKopekSayisiGetirResponse
//                    {
//                        YasGrubu = g.Key,
//                        ErkekSayisi = g.Count(k => k.Cinsiyet == "Erkek"),
//                        DisiSayisi = g.Count(k => k.Cinsiyet == "Dişi")
//                    })
//                    .OrderBy(g => g.YasGrubu)
//                    .ToListAsync(cancellationToken);

//                return Result<List<YasVeCinsiyeteGoreKopekSayisiGetirResponse>>.Success(result);

//            }
//        }
//    }

//    public class GetAgeAndGenderDistributionEndpoint : ICarterModule
//    {
//        public void AddRoutes(IEndpointRouteBuilder app)
//        {
//            app.MapGet("dashboard/yasVeCinsiyeteGoreKopekSayisi", async (ISender sender) =>
//            {
//                var request = new GetAgeAndGenderDistribution.Query();
//                var response = await sender.Send(request);

//                if (response.Succeeded)
//                    return Results.Ok(response);
//                return Results.BadRequest(response);

//            }).WithTags(EndpointConstants.DASHBOARD);
//        }
//    }

//}
