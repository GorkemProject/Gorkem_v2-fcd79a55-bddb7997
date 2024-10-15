namespace Gorkem_.Contracts.Komisyon
{
    public class KomisyonEkleRequest
    {
        public int Id { get; set; }
        public string? KomisyonAdi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public string? GorevYeri { get; set; }
    }
}
