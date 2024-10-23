using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.Komisyon
{
    public class KomisyonUyeEkleRequest
    {
        public string? TcKimlikNo { get; set; }
        public string? AdSoyad { get; set; }
        public int Sicil { get; set; }
        public string? GorevUnvani { get; set; }
        public int GorevYeriId { get; set; }

        public string? Eposta { get; set; }
        public string? CepTelefonu { get; set; }
    }
}
