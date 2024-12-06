namespace Gorkem_.Contracts.KopekKurs
{
    public class HaftalikDegerlendirmeRaporuOlusturRequest
    {
        public int KursId { get; set; }
        public List<GozlemEkleRequest> Gozlemler { get; set; }
    }
}
