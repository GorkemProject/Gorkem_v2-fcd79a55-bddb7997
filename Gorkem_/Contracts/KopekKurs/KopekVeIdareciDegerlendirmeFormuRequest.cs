namespace Gorkem_.Contracts.KopekKurs
{
    public class KopekVeIdareciDegerlendirmeFormuRequest
    {
        public int Id { get; set; }
        public int TestinYapildigiIlId { get; set; }
        public string TestinYapildigiYer { get; set; } = string.Empty;
        public DateTime TarihSaat { get; set; }
        public int KursId { get; set; }
        public List<KursDegerlendirmeCevapRequest> KursDegerlendirmeCevaplar { get; set; } 
    }
}
