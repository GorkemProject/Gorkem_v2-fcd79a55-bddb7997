namespace Gorkem_.Contracts.Komisyon
{
    public class KomisyonUyeleriListeleResponse
    {
        public int Id { get; set; }
        public string? TcKimlikNo { get; set; }
        public string? AdSoyad { get; set; }
        public int? Sicil { get; set; }
        public string? GorevUnvani { get; set; }
        public string? GorevYeri { get; set; }
        public int GorevYeriId { get; set; }

        public string? Eposta { get; set; }
        public string? CepTelefonu { get; set; }
    }
}
