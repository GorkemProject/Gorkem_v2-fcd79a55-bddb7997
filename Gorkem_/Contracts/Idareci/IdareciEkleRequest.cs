using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.Idareci
{
    public class IdareciEkleRequest
    {
        public int Sicil { get; set; }
        public string AdSoyad { get; set; } = string.Empty;
        public string CepTelefonu { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; }

        public int IdareciDurumId { get; set; }
        public KT_IdareciDurum IdareciDurum { get; set; } = new();

        public int BirimId { get; set; }
        public KT_Birim Birim { get; set; } = new();

        public int BransId { get; set; }
        public KT_Brans Brans { get; set; } = new();

        public int RutbeId { get; set; }
        public KT_Rutbe Rutbe { get; set; } = new();

        public int AskerlikId { get; set; }
        public KT_Askerlik Askerlik { get; set; } = new();

        public List<KT_OgrenimDurumu> OgrenimDurumu { get; set; } = new();
        public List<KT_YabanciDil> YabanciDil { get; set; } = new();
    }
}
