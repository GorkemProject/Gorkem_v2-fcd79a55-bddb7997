namespace Gorkem_.Contracts.Kopek
{
    public class KopekGetirResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IrkRef { get; set; }
        public int BirimRef { get; set; }
        public int BransRef { get; set; }
        public int KopekTuruRef { get; set; }
        public int DurumRef { get; set; }
        public int KuvveNumarasi { get; set; }
        public int CipNumarasi { get; set; }
        public bool Karar { get; set; }
        public DateTime T_Aktif { get; set; }
        public DateTime? T_Pasif { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string? YapilanIslem { get; set; }
        public string? NihaiKanaat { get; set; }
        public string? TeminSekli { get; set; }
    }
}
