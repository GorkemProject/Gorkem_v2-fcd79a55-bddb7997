namespace Gorkem_.Contracts.Komisyon
{
    public class KomisyonGetirFilterResponse
    {
        public int Id { get; set; }
        public string? KomisyonAdi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public string? GorevYeri { get; set; }
        public int GorevYeriId { get; set; }
    }
}
