using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.KodTablo;
using Gorkem_.EndpointTags;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Gorkem_.Features.KodTablo
{
    public static class DeleteYabanciDil
    {
        public class Command : IRequest<Result<bool>>
        {
            public int Id { get; set; }

        }
        public class DeleteYabanciDilValidation : AbstractValidator<Command>
        {
            public DeleteYabanciDilValidation() 
            { 
                RuleFor(r=>r.Id).GreaterThanOrEqualTo(0).Configure(r=>r.MessageBuilder=_=> "Id Boş olamaz");
            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
 
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentYabanciDil = await Context.KT_YabanciDils.FirstOrDefaultAsync(r => r.Id == request.Id && r.Aktifmi);
                if (currentYabanciDil is null) return await Result<bool>.FailAsync($"With the {request.Id} Id data could not found");

                currentYabanciDil.Aktifmi = false;
                currentYabanciDil.T_Pasif = DateTime.Now;
                var isDeleted = await Context.SaveChangesAsync() > 0;

                if (isDeleted)
                    return await Result<bool>.SuccessAsync(true);
                return await Result<bool>.FailAsync("Silme işlemi yapılamadı");
              
                
            }
        }

    }
    public class DeleteYabanciDilEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
           var mapGet= app.MapDelete("kodtablo/yabancidil", async ([FromBody] YabanciDilSilRequest model, ISender sender) =>
            {
                var request = new DeleteYabanciDil.Command() { Id = model.Id };
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
