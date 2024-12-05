using Gorkem_.Context.Entities;

namespace Gorkem_.Contracts.KopekKurs
{
    public class KursiyerKaydetRequest
    {
        public int Id { get; set; }
        public int Sicil { get; set; }

        public string? PersonelAdi { get; set; }

        public string? CipNumarası { get; set; }

        public int KursId { get; set; }


    }
}
