using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KursEkleRequest
    {
        public int Id { get; set; }
        public DateTime? T_KursBaslangic { get; set; }
        public DateTime? T_KursBitis { get; set; }
        public int? KursYeriId { get; set; }
        public int? KursEgitimListesiId { get; set; }
        public int Donem { get; set; }
    }

}
