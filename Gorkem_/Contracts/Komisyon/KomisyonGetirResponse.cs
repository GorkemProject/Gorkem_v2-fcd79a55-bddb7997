namespace Gorkem_.Contracts.Komisyon
{
    public class KomisyonGetirResponse
    {
        public int Id { get; set; }
        public string? KomisyonAdi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int GorevYeriId { get; set; }
    }
}
