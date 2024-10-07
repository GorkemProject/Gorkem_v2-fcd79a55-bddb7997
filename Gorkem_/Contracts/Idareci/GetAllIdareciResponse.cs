using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.Idareci
{
    public class GetAllIdareciResponse
    {
        public int Sicil { get; set; }
        public string AdSoyad { get; set; } = string.Empty;
        public string CepTelefonu { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; }
        public int IdareciDurumId { get; set; }
        public int BirimId { get; set; }

        public int BransId { get; set; }

        public int RutbeId { get; set; }

        public int AskerlikId { get; set; }


    }
}
