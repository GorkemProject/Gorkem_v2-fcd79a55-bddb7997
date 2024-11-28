namespace Gorkem_.Context.Entities
{
    public class UT_KursKopekDegerlendirmeCevap :UTBaseEntity
    {

        public int KopekDegerlendirmeSoruId { get; set; }
        public virtual KT_KursKopekDegerlendirmeSorular? KopekDegerlendirmeSoru { get; set; }
        public int KapaliAlanPuan { get; set; }
        public int AracPuan { get; set; }
        public int TasinabilirEsyaPuan { get; set; }
        public int KopekId { get; set; }
        public virtual UT_Kopek? Kopek { get; set; }

        public virtual ICollection<UT_KopekVeIdareciDegerlendirmeFormu>? KopekVeIdareciDegerlendirmeFormu { get; set; }


    }
}
