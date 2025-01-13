using AspNetCoreHero.Results;
using Carter;
using FluentValidation;
using Gorkem_.Context;
using Gorkem_.Contracts.Kopek;
using Gorkem_.EndpointTags;
using Gorkem_.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Gorkem_.Features.Kopek
{
    public class UpdateKopek
    {
        public class Command : IRequest<Result<bool>> 
        {
            public int Id { get; set; }
            public string KopekAdi { get; set; }
            public int IrkId { get; set; }
            public int KadroIlId { get; set; }
            public int BransId { get; set; }
            public string? KuvveNumarasi { get; set; }
            public string? CipNumarasi { get; set; }
            public DateTime DogumTarihi { get; set; }
            public string YapilanIslem { get; set; }
            public string NihaiKanaat { get; set; }
            public int KararId { get; set; }
            public Enum_Cinsiyet Cinsiyet { get; set; }
            public Enum_TeminSekli EdinimSekli { get; set; }
            public int? AnneKopekId { get; set; }
            public int? BabaKopekId { get; set; }
            public string? EdinilenKisi { get; set; }
            public string? EdinilenKisiAdres { get; set; }
            public string? EdinilenKisiTelefon { get; set; }
            public DateTime EdinilmeTarihi { get; set; }
            public string ProfileImage { get; set; }
        }
        public class UpdateKopekValidation : AbstractValidator<Command>
        {
            public UpdateKopekValidation()
            {
                RuleFor(r => r.KopekAdi).NotEmpty().NotNull().WithMessage("İsim Alanı Boş Bırakılamaz.");
                RuleFor(r => r.IrkId).NotEmpty().NotNull().WithMessage("Irk Alanı Boş Bırakılamaz.");
                RuleFor(r => r.KadroIlId).NotEmpty().NotNull().WithMessage("Birim Alanı Boş Bırakılamaz.");
                RuleFor(r => r.KuvveNumarasi).NotEmpty().NotNull().WithMessage("Kuvve Numarası Alanı Boş Bırakılamaz.");
                RuleFor(r => r.CipNumarasi).NotEmpty().NotNull().WithMessage("Çip Numarası Alanı Boş Bırakılamaz.");
                RuleFor(r => r.YapilanIslem).NotEmpty().NotNull().WithMessage("Yapılan işlem Alanı Boş Bırakılamaz.");
                RuleFor(r => r.NihaiKanaat).NotEmpty().NotNull().WithMessage("Nihai Kanaat Alanı Boş Bırakılamaz.");

            }
        }
        internal sealed record Handler(GorkemDbContext Context, Serilog.ILogger Logger) : IRequestHandler<Command, Result<bool>>
        {
 
            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {
                var kopek = await Context.UT_Kopek_Kopeks.FindAsync(request.Id);
                if (kopek==null)
                {
                    return await Result<bool>.FailAsync("Köpek Bulunamadı..");
                }
                    
                kopek.KopekAdi = request.KopekAdi;
                kopek.IrkId = request.IrkId;
                kopek.KadroIlId = request.KadroIlId;
                kopek.BransId = request.BransId;
                kopek.KuvveNumarasi = request.KuvveNumarasi;
                kopek.CipNumarasi = request.CipNumarasi;
                kopek.DogumTarihi = request.DogumTarihi;
                kopek.YapilanIslem = request.YapilanIslem;
                kopek.NihaiKanaat = request.NihaiKanaat;
                kopek.KararId = request.KararId;
                kopek.Cinsiyet=request.Cinsiyet;
                kopek.EdinimSekli = request.EdinimSekli;
                kopek.AnneKopekId=request.AnneKopekId;
                kopek.BabaKopekId=request.BabaKopekId;
                kopek.EdinilenKisi = request.EdinilenKisi;
                kopek.EdinilenKisiAdres = request.EdinilenKisiAdres;
                kopek.EdinilenKisiTelefon=request.EdinilenKisiTelefon;
                kopek.EdinilmeTarihi = request.EdinilmeTarihi;
                kopek.ProfileImage=request.ProfileImage;
                
                
                var isSaved = await Context.SaveChangesAsync(cancellationToken)>0;
                if (isSaved)
                {
                    Logger.Information("{0} kaydı {1} tarafından {2} Zamanında Eklendi", request.KopekAdi, "DemoAccount", DateTime.Now);
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
            app.MapPut("kopek/{id}/UpdateKopek", async (int id, [FromBody] UpdateKopek.Command model, ISender sender) =>
            {
               
                model.Id = id;
                var result = await sender.Send(model);
                if (result.Succeeded)
                {
                    return Results.Ok(result);
                }
                return Results.BadRequest(result);
            }).WithTags(EndpointConstants.KOPEK);

        }
    }
}
