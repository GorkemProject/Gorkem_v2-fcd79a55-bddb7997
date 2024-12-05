using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KursiyerGetirResponse
    {
        //public int KursiyerId { get; set; }
        //public string? KursiyerAdi { get; set; }
        //public List<KursiyerKopekleriResponse> Kopekler { get; set; }

        public int Sicil { get; set; }

        public string? PersonelAdi { get; set; }

        public string KopekName { get; set; }
        public string? CipNumarası { get; set; }

        public int KursDonem { get; set; }
        public string? KursAdi { get; set; }
    }
}
