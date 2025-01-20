using Gorkem_.Enums;

namespace Gorkem_.Contracts.SecimTest
{
    public class SecimTestiGetirFilterResponse
    {
        //public int KopekId { get; set; }

        //public int IdareciId { get; set; }
        //public int SecimTestId { get; set; }
        //public int SinavYeriId { get; set; }
        //public DateTime Tarih { get; set; }
        //public Enum_SecimTestBrans SecimTestBrans { get; set; }
        //public int ToplamPuan { get; set; }


        public int Id { get; set; }
        public int KopekId { get; set; }
        public string KopekName { get; set; }
        public Enum_Cinsiyet KopekCinsiyet { get; set; }

        public int SecimTestId { get; set; }
        public string SecimTestName { get; set; }
        public int SinavYeriId { get; set; }
        public string SinavYeriName { get; set; }
        public DateTime Tarih { get; set; }
        public bool TepkiSekli { get; set; }
        public bool Havlama { get; set; }
        public Enum_SecimTestBrans SecimTestBrans { get; set; }
        public string Degerlendirme { get; set; }
        public int? KomisyonId { get; set; }
        public string KomisyonName { get; set; }
        public int ToplamPuan { get; set; }

    }
}
