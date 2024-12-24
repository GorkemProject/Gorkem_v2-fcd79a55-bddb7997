using System.Reflection.Metadata.Ecma335;

namespace Gorkem_.Context.Entities
{
    public class UT_KopekVeIdareciDegerlendirmeFormu :UTBaseEntity
    {


        public int TestinYapildigiIlId { get; set; }
        public virtual KT_GorevYeri? TestinYapildigiIl { get; set; }
        public string? TestinYapildigiYer { get; set; }
        public DateTime TarihSaat { get; set; }
        public int KursId { get; set; }
        public virtual UT_Kurs? Kurs { get; set; }
        public virtual ICollection<UT_KursDegerlendirmeCevap>? KursDegerlendirmeCevaplar { get; set; }




    }
}
