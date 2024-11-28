namespace Gorkem_.Contracts.KopekKurs
{
    public class KopekKursDegerlendirmeEkleRequest
    {
        public int Id { get; set; }
        public int KopekDegerlendirmeSoruId { get; set; }
        public int KapaliAlanPuan { get; set; }
        public int AracPuan { get; set; }
        public int TasinabilirEsyaPuan { get; set; }
        public int KopekId { get; set; }
    }
}
