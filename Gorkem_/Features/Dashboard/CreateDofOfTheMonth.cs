using AspNetCoreHero.Results;
using Azure.Core;
using Carter;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Dashboard;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Features.Dashboard
{
    public static class CreateDogOfTheMonth
    {
        public class Command : IRequest<Result<AyinKopegiEkleRequest>>
        {
            public int KopekId { get; set; }
        }

        public class Handler(GorkemDbContext Context) : IRequestHandler<Command, Result<AyinKopegiEkleRequest>>
        {
            public async Task<Result<AyinKopegiEkleRequest>> Handle(Command request, CancellationToken cancellationToken)
            {
                var kopek = await Context.UT_Kopek_Kopeks.FindAsync(request.KopekId);

                if (kopek == null)
                {
                    return Result<AyinKopegiEkleRequest>.Fail("Belirlilen köpek bulunamadı..");
                }

                var mevcutAyinKopegi = await Context.UT_AyinKopegis
                    .Where(a => a.Aktifmi == true)
                    .FirstOrDefaultAsync(cancellationToken);

                if (mevcutAyinKopegi != null) 
                { 
                    mevcutAyinKopegi.Aktifmi = false;
                    mevcutAyinKopegi.T_Pasif = DateTime.Now;
                }
                var ayinKopegi = new UT_AyinKopegi
                {
                    Aktifmi = true,
                    KopekId = kopek.Id,
                    T_Aktif = DateTime.Now,
                };

                Context.UT_AyinKopegis.Add(ayinKopegi);
                await Context.SaveChangesAsync(cancellationToken);

                return Result<AyinKopegiEkleRequest>.Success();
            }
        }

    }

    public class CreateDogOfTheMonthEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapPost("dashboard/CreateADogOfMoth", async ([FromBody] AyinKopegiEkleRequest command, ISender sender) =>
            {
                var request = new CreateDogOfTheMonth.Command {KopekId= command.KopekId };
                var response = await sender.Send(request);

                if(response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);

            }).WithTags(EndpointConstants.DASHBOARD);
            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
