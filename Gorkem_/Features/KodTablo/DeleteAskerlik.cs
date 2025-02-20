﻿using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal.Json;

namespace Gorkem_.Features.KodTablo
{
    public static class DeleteAskerlik
    {
        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }

        }
        public class DeleteAskerlikValidation : AbstractValidator<Command> 
        {
            public DeleteAskerlikValidation() 
            {
                RuleFor(r=>r.Id).GreaterThanOrEqualTo(0).Configure(r=>r.MessageBuilder =_=> "Id Boş Olamaz");
            }
        }
        public sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {   
            

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentAskerlik = await Context.KT_Askerliks.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentAskerlik is null) return await Result<bool>.FailAsync($"{request.Id} Id data could not found!");

                currentAskerlik.Aktifmi = false;
                currentAskerlik.T_Pasif = DateTime.Now;

                var isDeleted = await Context.SaveChangesAsync() > 0;
                if (isDeleted)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Silme İşlemi Yapılamadı");           

            }
        }
    }
    public class DeleteAskerlikEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var mapGet=app.MapDelete("kodtablo/askerlik", async ([FromBody] AskerlikSilRequest model, ISender sender) =>
            {
                var request = new DeleteAskerlik.Command() { Id = model.Id };
                var response = await sender.Send(request);

                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KODTABLO);

            if (app.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsProduction())
            {
                mapGet.RequireAuthorization();
            }
        }
    }
}
