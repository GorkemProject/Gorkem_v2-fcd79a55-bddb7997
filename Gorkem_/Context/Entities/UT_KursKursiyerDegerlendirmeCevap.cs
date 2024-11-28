using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Gorkem_.Context.Entities
{
    public class UT_KursKursiyerDegerlendirmeCevap : UTBaseEntity
    {

        public int KursiyerDegerlendirmeSoruId { get; set; }
        public virtual KT_KursKursiyerDegerlendirmeSorular? KursiyerDegerlendirmeSoru { get; set; }
        public int KapaliAlanPuan { get; set; }
        public int AracPuan { get; set; }
        public int TasinabilirEsyaPuan { get; set; }

        public int KursiyerId { get; set; }
        public virtual UT_Kursiyer? Kursiyer { get; set; }

        public virtual ICollection<UT_KopekVeIdareciDegerlendirmeFormu>? KopekVeIdareciDegerlendirmeFormu { get; set; }

    }
}
