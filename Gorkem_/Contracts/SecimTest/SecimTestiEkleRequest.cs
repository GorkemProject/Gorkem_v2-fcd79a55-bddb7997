using Gorkem_.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Gorkem_.Contracts.SecimTest
{
    public class SecimTestiEkleRequest
    {
        public int Id { get; set; }
        public int KopekId { get; set; }
        public int IdareciId { get; set; }
        public int SecimTestId { get; set; }
        public int SinavYeriId { get; set; }
        public DateTime Tarih { get; set; }
        public bool TepkiSekli { get; set; }
        public bool Havlama { get; set; }
        public Enum_SecimTestBrans SecimTestBrans { get; set; }
        public string Degerlendirme { get; set; }
        public string TestKomisyonu { get; set; }
        public int ToplamPuan { get; set; }

    }
}
