using System.Runtime.InteropServices.Marshalling;

namespace Gorkem_.Context.Entities
{
    public class UT_Kurs : UTBaseEntity
    {
        public DateTime? T_KursBaslangic { get; set; }
        public DateTime? T_KursBitis { get; set; }
        public int? KursYeriId { get; set; }
        public virtual KT_GorevYeri? KursYeri { get; set; }
        public int? KursEgitimListesiId  { get; set; }
        public virtual KT_KursEgitimListesi? KursEgitimListesi { get; set; }
        public int Donem { get; set; }
    }
}
