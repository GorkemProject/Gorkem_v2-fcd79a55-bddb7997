using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KopekKursGetirFilterResponse
    {

        public DateTime? T_KursBaslangic { get; set; }
        public DateTime? T_KursBitis { get; set; }
        public int? KursYeriId { get; set; }
        public string KursYeri { get; set; }
        public int? KursEgitimListesiId { get; set; }
        public string KursEgitimListesi { get; set; }
        public int Donem { get; set; }

        public string? KursEgitmenler { get; set; }
        public int KursEgitmenlerId { get; set; }
        public string? Kursiyerler { get; set; }
        public int KursiyerlerId { get; set; }

    }
}
