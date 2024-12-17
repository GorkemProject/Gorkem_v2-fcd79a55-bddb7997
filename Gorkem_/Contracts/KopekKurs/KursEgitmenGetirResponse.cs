using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KursEgitmenGetirResponse
    {
        public int Id { get; set; }
        public int Sicil { get; set; }
        public int? BirimId { get; set; }
        public string Birim { get; set; }
        public int? RutbeId { get; set; }
        public string Rutbe { get; set; }
        public string? AdSoyad { get; set; }
    }
}
