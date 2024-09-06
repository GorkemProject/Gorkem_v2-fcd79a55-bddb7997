using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Kopek;
using Gorkem_.EndpointTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Gorkem_.Features.Kopek
{
    public class UpdateKopek
    {
        public class Command : IRequest<Result<bool>> 
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int IrkId { get; set; }
            public int BirimId { get; set; }
            public int BransId { get; set; }
            public int CinsId { get; set; }
            public int KopekTuruId { get; set; }
            public int DurumId { get; set; }
            public int KuvveNumarasi { get; set; }
            public int CipNumarasi { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string YapilanIslem { get; set; }
            public string NihaiKanaat { get; set; }
            public int TeminSekli { get; set; }
        }
        public class UpdateKopekValidation : AbstractValidator<Command>
        {
            public UpdateKopekValidation()
            {
                RuleFor(r => r.Name).NotEmpty().NotNull().WithMessage("İsim Alanı Boş Bırakılamaz.");
                RuleFor(r => r.IrkId).NotEmpty().NotNull().WithMessage("Irk Alanı Boş Bırakılamaz.");
                RuleFor(r => r.BirimId).NotEmpty().NotNull().WithMessage("Birim Alanı Boş Bırakılamaz.");
                RuleFor(r => r.KopekTuruId).NotEmpty().NotNull().WithMessage("Köpek Türü Alanı Boş Bırakılamaz.");
                RuleFor(r => r.DurumId).NotEmpty().NotNull().WithMessage("Durum Alanı Boş Bırakılamaz.");
                RuleFor(r => r.KuvveNumarasi).NotEmpty().NotNull().WithMessage("Kuvve Numarası Alanı Boş Bırakılamaz.");
                RuleFor(r => r.CipNumarasi).NotEmpty().NotNull().WithMessage("Çip Numarası Alanı Boş Bırakılamaz.");
                RuleFor(r => r.YapilanIslem).NotEmpty().NotNull().WithMessage("Yapılan işlem Alanı Boş Bırakılamaz.");
                RuleFor(r => r.NihaiKanaat).NotEmpty().NotNull().WithMessage("Nihai Kanaat Alanı Boş Bırakılamaz.");
                RuleFor(r => r.TeminSekli).NotEmpty().NotNull().WithMessage("Temin Şekli Alanı Boş Bırakılamaz.");
            }
        }
        internal sealed class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly GorkemDbContext _context;
            public Handler(GorkemDbContext context)
            {
                _context = context;
            }
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var kopek = await _context.UT_Kopek_Kopeks.FindAsync(request.Id);
                if (kopek==null)
                {
                    return await Result<bool>.FailAsync("Köpek Bulunamadı..");
                }
                    
            
                kopek.IrkId = request.IrkId;
                kopek.BirimId = request.BirimId;
                kopek.BransId = request.BransId;
                kopek.KopekTuruId = request.KopekTuruId;
                kopek.DurumId = request.DurumId;
                kopek.KuvveNumarasi = request.KuvveNumarasi;
                kopek.CipNumarasi = request.CipNumarasi;
                kopek.DogumTarihi = request.DogumTarihi;
                kopek.YapilanIslem = request.YapilanIslem;
                kopek.NihaiKanaat = request.NihaiKanaat;
                kopek.TeminSekli = request.TeminSekli;
                
                var isSaved = await _context.SaveChangesAsync(cancellationToken)>0;
                if (isSaved)
                {
                    return await Result<bool>.SuccessAsync(true);
                }
                return await Result<bool>.FailAsync("Köpek Güncelleme Başarısız");
            }
        }
    }
    public class UpdateKopekEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("kopek/{id}", async (int id, [FromBody] UpdateKopek.Command model, ISender sender) =>
            {
               
                model.Id = id;
                var result = await sender.Send(model);
                if (result.Succeeded)
                {
                    return Results.Ok();
                }
                return Results.BadRequest(result.Message);
            }).WithTags(EndpointConstants.KOPEK);

        }
    }
}
