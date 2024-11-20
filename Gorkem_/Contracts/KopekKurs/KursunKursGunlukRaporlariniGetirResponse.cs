namespace Gorkem_.Contracts.KopekKurs
{
    public class KursunKursGunlukRaporlariniGetirResponse
    {
        public int KursId { get; set; }
        public string? KursAdi { get; set; }
        public DateTime T_DersTarihi { get; set; }
        public string? SinifAdi { get; set; }
        public List<KGRMufredatResponse> KGRMufredatlar { get; set; }
        public List<KursEgitmenResponse> KursEgitmenler { get; set; }
        public List<KursKursiyerResponse> KursKursiyer { get; set; }
    }
}
