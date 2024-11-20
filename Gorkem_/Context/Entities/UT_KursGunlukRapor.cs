using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gorkem_.Context.Entities
{
    public class UT_KursGunlukRapor : UTBaseEntity
    {
        public virtual UT_Kurs? Kurs { get; set; }
        public int  KursId { get; set; }

        public DateTime T_DersTarihi { get; set; }

        public string SinifAdi { get; set; }
        public virtual ICollection<UT_KGRMufredat>? KGRMufredatlar { get; set; }



    }
}
