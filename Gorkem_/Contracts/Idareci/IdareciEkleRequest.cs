namespace Gorkem_.Contracts.Idareci
{
    public class IdareciEkleRequest
    {
        public int Sicil { get; set; }
        public string AdSoyad { get; set; } = string.Empty;
        public string Rutbe { get; set; } = string.Empty;
        public string Kurum { get; set; } = string.Empty;
        public string Birim { get; set; } = string.Empty;
        public string CepTelefonu { get; set; } = string.Empty;
        public string AskerlikDurumu { get; set; } = string.Empty;
        public string Durum { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; }
        public List<string> Ogrenim { get; set; } = new();
        public List<string> YabanciDil { get; set; } = new();
    }
}
