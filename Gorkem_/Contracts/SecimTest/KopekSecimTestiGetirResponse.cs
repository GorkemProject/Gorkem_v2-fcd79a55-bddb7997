using Gorkem_.Context.Entities;
using Gorkem_.Enums;

namespace Gorkem_.Contracts.SecimTest
{
    public class KopekSecimTestiGetirResponse
    {
        public string? Kopek { get; set; }
        public int KopekId { get; set; }

        public int SecimTestId { get; set; }
        public string? SecimTest { get; set; }

        public string? SinavYeri { get; set; }
        public int SinavYeriId { get; set; }

        public DateTime Tarih { get; set; }

        public bool TepkiSekli { get; set; }
        public bool Havlama { get; set; }
        public Enum_SecimTestBrans SecimTestBrans { get; set; }
        public string Degerlendirme { get; set; }

        public string? Komisyon { get; set; }
        public int? KomisyonId { get; set; }
        public int ToplamPuan { get; set; }
        public string? ProfileImage { get; set; }
    }
}
