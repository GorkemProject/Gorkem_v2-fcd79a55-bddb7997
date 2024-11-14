using Gorkem_.Enums;

namespace Gorkem_.Contracts.SecimTest
{
    public class SecimTestiListeleRequest
    {
        public int? KopekId { get; set; }
        public int? KomisyonId { get; set; }
        public DateTime? BaslangicTarih { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public int? SinavYeriId { get; set; }
        public int? SecimTestId { get; set; }
        public int? PuanAltSinir { get; set; }
        public int? PuanUstSinir { get; set; }
        public int? IrkId { get; set; }
        public Enum_Cinsiyet? Cinsiyet { get; set; }

        //Sayfalama için gereken parametreler

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        //Sıralama için gereken parametreler

        public string SortBy { get; set; }
        public bool IsAscending { get; set; } = true;
    }
}
