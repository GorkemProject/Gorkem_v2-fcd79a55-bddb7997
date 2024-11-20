namespace Gorkem_.Context.Entities
{
    public class UT_KGRMufredat :UTBaseEntity
    {

        public virtual KT_KursMufredat? Mufredat { get; set; }
        public int MufredatId { get; set; }

        public virtual ICollection<UT_KursGunlukRapor>? KursGunlukRapor { get; set; }


    }
}
