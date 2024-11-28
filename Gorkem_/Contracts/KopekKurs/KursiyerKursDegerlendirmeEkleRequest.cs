using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KursiyerKursDegerlendirmeEkleRequest
    {
        public int Id { get; set; }

        public int KursiyerDegerlendirmeSoruId { get; set; }
        public int KapaliAlanPuan { get; set; }
        public int AracPuan { get; set; }
        public int TasinabilirEsyaPuan { get; set; }
        public int KursiyerId { get; set; }
    }
}
