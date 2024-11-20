namespace Gorkem_.Contracts.KopekKurs
{
    public class KursiyerGetirResponse
    {
        public int KursiyerId { get; set; }
        public string? KursiyerAdi { get; set; }
        public List<KursiyerKopekleriResponse> Kopekler { get; set; }
    }
}
