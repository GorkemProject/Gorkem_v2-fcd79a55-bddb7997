namespace Gorkem_.Contracts.Kopek
{
    public class KopekGetirResponse
    {
        public int Id { get; set; }
        public string? KopekAdi { get; set; }
        public int IrkId { get; set; }
        public int KadroIlId { get; set; }
        public int BransId { get; set; }
        public string? KuvveNumarasi { get; set; }
        public string? CipNumarasi { get; set; }
        public int Karar { get; set; }
        public DateTime T_Aktif { get; set; }
        public DateTime? T_Pasif { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string? YapilanIslem { get; set; }
        public string? NihaiKanaat { get; set; }
    }
}
