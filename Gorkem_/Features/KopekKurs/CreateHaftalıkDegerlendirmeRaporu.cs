using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Context.Entities;
using Gorkem_.Contracts.KopekKurs;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace Gorkem_.Features.KopekKurs
{
    public static class CreateHaftalıkDegerlendirmeRaporu
    {

        public record Command(HaftalikDegerlendirmeRaporuOlusturRequest Request) : IRequest<Result<bool>>;

        internal sealed class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly GorkemDbContext _context;
            private readonly Serilog.ILogger _logger;
            public Handler(GorkemDbContext context, Serilog.ILogger logger )
            {
                _context = context;
                _logger = logger;
            }

            
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
  
                var yeniRapor = request.Request.Gozlemler.Select(g => new UT_HaftalıkDegerlendirmeRaporuGozlemler
                {
                    KursId = request.Request.KursId,
                    KursiyerId = g.KursiyerId,
                    Gozlemler = g.Gozlemler,
                    Aktifmi = true,
                    T_Aktif = DateTime.Now,
                    Hafta = request.Request.Hafta
                }).ToList();

                _context.UT_HaftalıkDegerlendirmeRaporuGozlemlers.AddRange(yeniRapor);

                var isSaved = await _context.SaveChangesAsync()>0;

                if (isSaved)
                {
                    _logger.Information("Rapor ve gözlemler başarıyla eklendi.");
                    return await Result<bool>.SuccessAsync(true);
                }

                return await Result<bool>.FailAsync("rapor oluşturulamadı..");
            }
        }


    }

    public class CreateHaftalikDegerlendirmeRaporuEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("kopekKurs/CreateHaftalikDegerlendirmeRaporu", async ([FromBody] HaftalikDegerlendirmeRaporuOlusturRequest model, ISender sender) =>
            {
                var request = new CreateHaftalıkDegerlendirmeRaporu.Command(model);
                var response = await sender.Send(request);
                if (response.Succeeded)
                    return Results.Ok(response);
                return Results.BadRequest(response);
            }).WithTags(EndpointConstants.KOPEKKURS);
        }
    }
}
