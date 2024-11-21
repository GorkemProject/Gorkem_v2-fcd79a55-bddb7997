using Gorkem_.Context.Entities;
using Gorkem_.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gorkem_.Contracts.Kopek
{
    public class KopekListeleRequest
    {
        public int IrkId { get; set; }//
        //public int? KuvveNumarasiUstSinir { get; set; }//
        //public int? KuvveNumarasiAltSinir { get; set; }//
        public int? CipNumarasiUstSinir { get; set; }//
        public int? CipNumarasiAltSinir { get; set; }//
        public int KadroIlId { get; set; }//
        public DateTime DogumTarihiBaslangic { get; set; }//
        public DateTime DogumTarihiBitis { get; set; }//

        public int KararId { get; set; }//
        public Enum_Cinsiyet? Cinsiyet { get; set; }//
        public Enum_TeminSekli? EdinimSekli { get; set; }//

        public Enum_KopekDurum? KopekDurum { get; set; }//
        public int? BirimId { get; set; }//

        //Sayfalama için gereken parametreler

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        //Sıralama için gereken parametreler

        public string SortBy { get; set; }
        public bool IsAscending { get; set; } = true;

    }
}
