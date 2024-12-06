namespace Gorkem_.Context.Entities
{
    public class UT_HaftalıkDegerlendirmeRaporuGozlemler : UTBaseEntity
    {

        public int KursiyerId { get; set; }
        public virtual UT_Kursiyer? Kursiyer { get; set; }
        public string? Gozlemler { get; set; }
        public int KursId { get; set; }
        public virtual UT_Kurs? Kurs { get; set; }
        public int Hafta { get; set; }


    }
}
