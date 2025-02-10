namespace Gorkem_.Contracts.Idareci
{
    public class IdareciGetirResponse
    {
        public int Id { get; set; }
        public int Sicil { get; set; }
        public string AdSoyad { get; set; } = string.Empty;
        public string CepTelefonu { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; }
        public int IdareciDurumId { get; set; }
        public int GorevYeriId { get; set; }
        public int BransId { get; set; }

        public int RutbeId { get; set; }
        public int AskerlikId { get; set; }


    }
}
