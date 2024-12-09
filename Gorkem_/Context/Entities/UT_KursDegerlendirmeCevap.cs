namespace Gorkem_.Context.Entities
{
    public class UT_KursDegerlendirmeCevap :UTBaseEntity
    {

        //public int KopekDegerlendirmeSoruId { get; set; }
        //public virtual KT_KursKopekDegerlendirmeSorular? KopekDegerlendirmeSoru { get; set; }
        //public int KapaliAlanPuan { get; set; }
        //public int AracPuan { get; set; }
        //public int TasinabilirEsyaPuan { get; set; }
        //public int KopekId { get; set; }
        //public virtual UT_Kopek? Kopek { get; set; }

        //public virtual ICollection<UT_KopekVeIdareciDegerlendirmeFormu>? KopekVeIdareciDegerlendirmeFormu { get; set; }

        public int DegerlendirmeSoruId { get; set; }
        public virtual KT_KursDegerlendirmeSorular DegerlendirmeSoru { get; set; }
        public int KapaliAlanPuan { get; set; }
        public int AracPuan { get; set; }
        public int TasinabilirEsyaPuan  { get; set; }

        //Kopekler için 1, kursiyerler için 2
        public int DegerlendirmeTuru { get; set; }
        public int DegerlendirilenVarlikId { get; set; }
    }
}
