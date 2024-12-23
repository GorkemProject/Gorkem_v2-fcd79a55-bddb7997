using System.Reflection.Metadata.Ecma335;
using Gorkem_.Context.Entities;
using Gorkem_.Enums;

namespace Gorkem_.Contracts.Idareci
{
    public class IdareciEkleRequest
    {
        public int Sicil { get; set; }
        public string AdSoyad { get; set; } = string.Empty;
        public string CepTelefonu { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; } 
        public int IdareciDurumId { get; set; } 
        public int KadroIlId { get; set; } 
        public int BransId { get; set; } 
        public int RutbeId { get; set; } 
        public int AskerlikId { get; set; }
        public int OgrenimDurumuId { get; set; }
        public int YabanciDilId { get; set; }
        public int Puan { get; set; }
        public Enum_AdayPersonelDurum PersonelDurum  { get; set; }
        public int TestiYapanSicil { get; set; }
        public DateTime TestTarihi { get; set; }

    }
}
