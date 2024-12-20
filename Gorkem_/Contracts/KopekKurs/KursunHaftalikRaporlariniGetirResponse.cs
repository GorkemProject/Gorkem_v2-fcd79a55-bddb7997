namespace Gorkem_.Contracts.KopekKurs
{
    public class KursunHaftalikRaporlariniGetirResponse
    {
        public int KursDonemi { get; set; }
        public string? EgitimProgramiAdi { get; set; }
        public List<KursEgitmenResponse> KursEgitmenler { get; set; }
        public int KursiyerSayisi { get; set; }
        public DateTime? KursBaslangicTarih { get; set; }
        public  DateTime? KursBitisTarih { get; set; }

        public int KursiyerId { get; set; }
        public string? Kursiyer { get; set; }
        public int GozlemId { get; set; }
        public string? GozlemAdi { get; set; }
        public int KopekId { get; set; }
        public string KopekAdi { get; set; }


    }
}
