namespace Gorkem_.Contracts.KopekKurs
{
    public class KursunHaftalikRaporlariniGetirResponse
    {
        public string Hafta { get; set; }
        public List<HaftalıkRaporGozlemResponse> Gozlemler { get; set; }
    }

    public class HaftalıkRaporGozlemResponse
    {
        public string KursiyerAdi { get; set; }
        public string KopekAdi { get; set; }
        public string Gozlem { get; set; }

    }
}
