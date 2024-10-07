namespace Gorkem_.Contracts.Kopek
{
    public class KopekEkleRequest
    {
        public string KopekAdi { get; set; }
        public int IrkId { get; set; }
        public int BirimId { get; set; }
        public int BransId { get; set; }
        public int KuvveNumarasi { get; set; }
        public int CipNumarasi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string? YapilanIslem { get; set; }
        public string? NihaiKanaat { get; set; }
        public int KopekTuruId { get; set; }
        public bool Karar { get; set; }

    }
}
