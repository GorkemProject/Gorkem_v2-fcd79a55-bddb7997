namespace Gorkem_.Contracts.Idareci
{
    public class IdareciGetirFilterResponse
    {
        public int Id { get; set; }
        public int Sicil { get; set; }
        public string AdSoyad { get; set; } = string.Empty;
        public string CepTelefonu { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; }
        public int IdareciDurumId { get; set; }
        public string? IdareciDurum { get; set; } 
        public int KadroIlId { get; set; }
        public string? KadroIl { get; set; } 
        public int KopekId { get; set; }
        public string? Kopek { get; set; } 
        public int BransId { get; set; }
        public string? Brans { get; set; } 
        public int RutbeId { get; set; }
        public string? Rutbe { get; set; }
        public int AskerlikId { get; set; }
        public string? Askerlik { get; set; }
        public List<string>? OgrenimDurumlari { get; set; }
        public List<string>? YabanciDiller { get; set; }
        public int Puan { get; set; }

    }
}
