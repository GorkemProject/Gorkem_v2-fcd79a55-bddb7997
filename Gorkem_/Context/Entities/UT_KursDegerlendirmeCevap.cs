namespace Gorkem_.Context.Entities
{
    public class UT_KursDegerlendirmeCevap :UTBaseEntity
    {



        public int DegerlendirmeSoruId { get; set; }
        public virtual KT_KursDegerlendirmeSorular DegerlendirmeSoru { get; set; }
        public int KapaliAlanPuan { get; set; }
        public int AracPuan { get; set; }
        public int TasinabilirEsyaPuan  { get; set; }

        //Kopekler için 1, kursiyerler için 2
        public int DegerlendirmeTuru { get; set; }
        public int KursiyerId { get; set; }
        public virtual UT_Kursiyer Kursiyer { get; set; }
        public int KursId { get; set; }
    }
}
