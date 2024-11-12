using Gorkem_.Enums;

namespace Gorkem_.Contracts.KopekAtama
{
    public class KopegeBirimEkleRequest
    {
        public int KopekId { get; set; }
        public int BirimTabloID { get; set; }
        public string? AtamaEvrakSayisi { get; set; }
        public Enum_AtamaTuru AtamaTuru { get; set; }
        //public int IdareciId { get; set; }

    }
}
