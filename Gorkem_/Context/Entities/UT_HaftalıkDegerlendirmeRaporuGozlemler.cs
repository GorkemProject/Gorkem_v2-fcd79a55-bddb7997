namespace Gorkem_.Context.Entities
{
    public class UT_HaftalıkDegerlendirmeRaporuGozlemler : UTBaseEntity
    {

        public int HaftalikDegerlendirmeRaporuId { get; set; }
        public virtual UT_KursHaftalıkDegerlendirmeRaporu? HaftalikDegerlendirmeRaporu { get; set; }
        public int KursiyerId { get; set; }
        public virtual UT_Kursiyer? Kursiyer { get; set; }
        public string? Gozlemler { get; set; }


    }
}
