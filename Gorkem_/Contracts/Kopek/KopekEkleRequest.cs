using Gorkem_.Context.Entities;
using Gorkem_.Enums;

namespace Gorkem_.Contracts.Kopek
{
    public class KopekEkleRequest
    {
        public string KopekAdi { get; set; }
        public int IrkId { get; set; }
        public int KadroIlId { get; set; }
        public int BransId { get; set; }
        public string? CipNumarasi { get; set; }
        public string? KuvveNumarasi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string? YapilanIslem { get; set; }
        public string? NihaiKanaat { get; set; }
        public int KararId { get; set; }
        public Enum_Cinsiyet Cinsiyet { get; set; }
        public Enum_TeminSekli EdinimSekli { get; set; }
        public int? AnneKopekId { get; set; }
        public int? BabaKopekId { get; set; }
        public string? EdinilenKisi { get; set; }
        public string? EdinilenKisiAdres { get; set; }
        public string? EdinilenKisiTelefon { get; set; }
        public DateTime EdinilmeTarihi { get; set; }

    }
}
