namespace Gorkem_.Context.Entities
{
    public class UT_KursHaftalıkDegerlendirmeRaporu :UTBaseEntity
    {
        public int KursId { get; set; }
        public virtual UT_Kurs? Kurs { get; set; }

        public ICollection<UT_HaftalıkDegerlendirmeRaporuGozlemler>? HaftalıkDegerlendirmeRaporuGozlemler { get; set; }
    }
}
