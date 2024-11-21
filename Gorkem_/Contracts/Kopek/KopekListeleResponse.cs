using Gorkem_.Enums;

namespace Gorkem_.Contracts.Kopek
{
    public class KopekListeleResponse
    {
        public string KopekAdi { get; set; }
        public int IrkId { get; set; }//
        public string? KuvveNumarasi { get; set; }//
        public string? CipNumarasi { get; set; }//
        public int KadroIlId { get; set; }//
        public DateTime T_Aktif { get; set; }//
        

        public int KararId { get; set; }//
        public Enum_Cinsiyet Cinsiyet { get; set; }//
        public Enum_TeminSekli EdinimSekli { get; set; }//

        public Enum_KopekDurum KopekDurum { get; set; }//
        public int? BirimId { get; set; }//

    }
}
