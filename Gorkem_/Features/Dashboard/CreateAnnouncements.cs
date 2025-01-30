using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using FluentValidation.AspNetCore;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.Dashboard;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace Gorkem_.Features.Dashboard
{
    public static class CreateAnnouncements
    {
       public record Command(DuyuruEkleRequest Request) : IRequest<Result<int>>
       {

       }
        public class CreateAnnouncementsValidation : AbstractValidator<Command>
        {
            public CreateAnnouncementsValidation() 
            {
                RuleFor(r => r.Request.Icerik).NotEmpty().NotNull().WithMessage("Komisyon içeriği boş bırakılamaz");
                RuleFor(r => r.Request.Baslik).NotEmpty().NotNull().WithMessage("Komisyon başlığı boş bırakılamaz");

            }  
        } 

        public static UT_Duyurular ToDuyurular (this Command command)
        {
            return new UT_Duyurular
            {
                Aktifmi = true,
                Baslik = command.Request.Baslik,
                Icerik = command.Request.Icerik,
                T_Aktif = DateTime.Now
            };
        }

        internal sealed record Handler(GorkemDbContext Context) : IRequestHandler<Command, Result<int>>
        {
            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var duyuru = request.ToDuyurular(); 
                Context.UT_Duyurulars.Add(duyuru);

                var isSaved = await Context.SaveChangesAsync() > 0;
                if (isSaved)
                    return await Result<int>.SuccessAsync(duyuru.Id);
                return await Result<int>.FailAsync("Kayıt başarılı değil");
                
            }
        }

    }

    public class CreateAnnouncementsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapPost("dashboard/CreateAnnouncements", async ([FromBody] DuyuruEkleRequest model, ISender sender) =>
            {
                var request = new CreateAnnouncements.Command(model);
                var response = await sender.Send(request);

                if (response.Succeeded)
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
