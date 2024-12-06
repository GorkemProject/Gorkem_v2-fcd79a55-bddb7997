using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Gorkem_.Contracts.KopekKurs
{
    public class HaftalikDegerlendirmeRaporuOlusturRequest
    {
        public int KursId { get; set; }
        public int Hafta { get; set; }
        public List<GozlemEkleRequest> Gozlemler { get; set; }
    }
}
