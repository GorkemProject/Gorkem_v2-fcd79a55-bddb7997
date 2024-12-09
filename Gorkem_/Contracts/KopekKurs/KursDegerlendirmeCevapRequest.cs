namespace Gorkem_.Contracts.KopekKurs
{
    public class KursDegerlendirmeCevapRequest
    {

        public int DegerlendirmeSoruId { get; set; } // Soruların ID'si
        public int KapaliAlanPuan { get; set; } // Kapalı alan için puan
        public int AracPuan { get; set; } // Araç kullanımı için puan
        public int TasinabilirEsyaPuan { get; set; } // Taşınabilir eşya kullanımı için puan
        public int DegerlendirmeTuru { get; set; } // 1: Köpek, 2: Kursiyer
        public int DegerlendirilenVarlikId { get; set; } // Değerlendirilen köpek/kursiyer ID'si
    }
}
