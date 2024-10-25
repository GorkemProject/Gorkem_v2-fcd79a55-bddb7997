using Gorkem_.Enums;

namespace Gorkem_.Contracts.SecimTest
{
    public class SecimTestiGetirFilterResponse
    {
        public int KopekId { get; set; }
        public int IdareciId { get; set; }
        public int SecimTestId { get; set; }
        public int SinavYeriId { get; set; }
        public DateTime Tarih { get; set; }
        public Enum_SecimTestBrans SecimTestBrans { get; set; }
        public int ToplamPuan { get; set; }
    }
}
