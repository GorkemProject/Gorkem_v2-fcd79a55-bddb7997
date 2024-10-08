namespace Gorkem_.Contracts.Idareci
{
    public class IdareciGetirFilterResponse
    {
        public int Sicil { get; set; }
        public string AdSoyad { get; set; } = string.Empty;
        public string CepTelefonu { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; }
        public int IdareciDurumId { get; set; }
        public string IdareciDurum { get; set; }
        public int BirimId { get; set; }
        public string Birim { get; set; }
        public int BransId { get; set; }
        public string Brans { get; set; }

        public int RutbeId { get; set; }
        public string Rutbe { get; set; }
        public string Askerlik { get; set; }

    }
}
