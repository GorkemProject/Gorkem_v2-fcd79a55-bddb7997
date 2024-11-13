namespace Gorkem_.Context.Entities
{
    public class KT_KursMufredat : KTBaseEntity
    {
        public int KursEgitimListesiId { get; set; }
        public virtual KT_KursEgitimListesi KursEgitimListesi { get; set; }
    }
}
