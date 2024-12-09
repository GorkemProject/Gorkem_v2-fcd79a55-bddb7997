namespace Gorkem_.Contracts.KopekKurs
{
    public class KursiyerKopekDegerlendirmeResponse
    {

        public int PersonelSicil { get; set; }
        public string PersonelAdi { get; set; }
        public List<DegerlendirmeCevapResponse> PersonelDegerlendirmeCevaplar { get; set; }

        public string KopekCip { get; set; }
        public string KopekAdi { get; set; }
        public List<DegerlendirmeCevapResponse> KopekDegerlendirmeCevaplar { get; set; }
    }
}
