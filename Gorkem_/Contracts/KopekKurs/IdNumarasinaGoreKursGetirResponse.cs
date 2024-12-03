namespace Gorkem_.Contracts.KopekKurs
{
    public class IdNumarasinaGoreKursGetirResponse
    {
        public int KursId { get; set; }
        public string? KursAdi { get; set; }
        public int Donemi { get; set; }
        public DateTime BaslangicTarih { get; set; }
        public DateTime BitisTarih { get; set; }
        public string KursYeri { get; set; }
    }
}
