namespace Gorkem_.Contracts.KopekKurs
{
    public class SicileGoreKursiyerGetirResponse
    {
        public string AdiSoyadi { get; set; }
        public int Sicil { get; set; }
        public string? KadroIl { get; set; }
        public List<SicileGoreKursiyerinKopeginiGetirResponse> KopekBilgileri { get; set; }
    }
}
