using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KopekVeKursiyerDegerlendirmeFormuGetirResponse
    {
        public string? TestinYapildigiIl { get; set; }
        public string? TestinYapildigiYer { get; set; }
        public DateTime TarihSaat { get; set; }
        public string? KursAdı { get; set; }
        public List<KopekDegerlendirmeCevaplarResponse> KopekDegerlendirmeCevaplar { get; set; }
        public List<KursiyerDegerlendirmeCevaplarResponse> KursiyerDegerlendirmeCevaplar { get; set; }
        public List<KopekDegerlendirmeFormuBilgilerResponse> KopekDegerlendirmeBilgiler { get; set; }
        public List<KursiyerDegerlendirmeFormuBilgilerResponse> KursiyerDegerlendirmeBilgiler { get; set; }
        public int? KopekKapaliAlanToplamPuan { get; set; }
        public int? KopekAracToplamPuan { get; set; }
        public int? KopekTasinabilirEsyaToplamPuan { get; set; }

        public int? KursiyerKapaliAlanToplamPuan { get; set; }
        public int? KursiyerAracToplamPuan { get; set; }
        public int? KursiyerTasinabilirEsyaToplamPuan { get; set; }

    }
}
