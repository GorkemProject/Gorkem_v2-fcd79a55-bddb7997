﻿using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gorkem_.Features.KodTablo
{
    public static class CreateBirim
    {
        public class Command : IRequest<Result<bool>>
        {
            
            public string Name { get; set; }
        }


        public class CreateBirimValidation : AbstractValidator<Command>
        {
            public CreateBirimValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().Configure(r => r.MessageBuilder = _ => "Ad Boş Olamaz");
            }
        }
        public static KT_Birim ToBirim(this Command command)
        {
            return new KT_Birim
            {
                Name = command.Name,
                //Kayıt Esnasında aktiflik durumu false olarak geldiği için bu kısmı ekledim. Aktifleştirilme Tarihini de ekledim.
                Aktifmi = true,
                T_Aktif = DateTime.Now

            };
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {

            
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var isExists = Context.KT_Birims.Any(r => r.Name == request.Name);
                if (isExists) return await Result<bool>.FailAsync($"{request.Name} is already exists");

                Context.KT_Birims.Add(request.ToBirim());
                var isSaved = await Context.SaveChangesAsync() > 0;

                if (isSaved)
                    return await Result<bool>.SuccessAsync(true);
                    

                return await Result<bool>.FailAsync("Kayıt başarılı değil");
            }
        }
    }
    public class CreateBirimEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kodtablo/birim", async ([FromBody] BirimEkleRequest model, ISender sender) =>
            {
                var request = new CreateBirim.Command() { Name = model.BirimAdi };

                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);
        }
    }

}
