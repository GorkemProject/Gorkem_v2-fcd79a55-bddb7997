namespace Gorkem_.Context.Entities
{
    public class UT_KursGunlukRaporDersler : UTBaseEntity
    {

        public int KursGunlukRaporId { get; set; }
        public virtual UT_KursGunlukRapor KursGunlukRapor { get; set; }

        public int DersId { get; set; }
        public virtual KT_KursMufredat? Ders { get; set; }
    }
}
