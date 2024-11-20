using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KursEgitmenEkleRequest
    {

        public int Sicil { get; set; }
        public int? BirimId { get; set; }
        public int? RutbeId { get; set; }
        public string? AdSoyad { get; set; }
    }
}
