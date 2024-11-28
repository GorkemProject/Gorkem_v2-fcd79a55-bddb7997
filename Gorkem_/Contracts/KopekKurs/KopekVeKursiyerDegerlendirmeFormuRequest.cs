using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KopekVeKursiyerDegerlendirmeFormuRequest
    {

        public int Id { get; set; }

        public int TestinYapildigiIlId { get; set; }
        public string? TestinYapildigiYer { get; set; }
        public DateTime TarihSaat { get; set; }
        public int KursId { get; set; }


    }
}
