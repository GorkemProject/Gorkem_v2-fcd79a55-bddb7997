namespace Gorkem_.Contracts.Komisyon
{
    public class KomisyonVeUyeleriResponse
    {
        public string? KomisyonAdi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public string? GorevYeri { get; set; }
        public List<UyeResponse> Uyeler { get; set; }

    }
}
