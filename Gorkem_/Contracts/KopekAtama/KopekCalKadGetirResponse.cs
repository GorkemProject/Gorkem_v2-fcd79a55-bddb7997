using Gorkem_.Enums;

namespace Gorkem_.Contracts.KopekAtama
{
    public class KopekCalKadGetirResponse
    {
        public int? KopekId { get; set; }
        public int? IdareciId { get; set; }
        public string? IdareciAdi { get; set; }
        public string? BirimAdi { get; set; }
        public DateTime? GoreveBaslamaTarihi { get; set; }
        public DateTime? EvrakAtamaTarihi { get; set; }
        public DateTime? IlisikKesmeTarihi { get; set; }
        public Enum_AtamaTuru? AtamaTuru { get; set; }
        public string? AtamaEvrakSayisi { get; set; }

    }
}
