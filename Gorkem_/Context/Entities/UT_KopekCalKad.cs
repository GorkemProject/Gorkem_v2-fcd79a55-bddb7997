using Gorkem_.Enums;

namespace Gorkem_.Context.Entities
{
    public class UT_KopekCalKad : UTBaseEntity
    {
        public virtual UT_Kopek? Kopek { get; set; }
        public int? KopekId { get; set; }
        public virtual UT_AdayIdareci? AdayIdareci { get; set; }
        public int? AdayIdareciId { get; set; }

        public virtual KT_Birim? Birim { get; set; }
        public int? BirimId { get; set; }
        public DateTime? T_GoreveBaslama { get; set; }
        public DateTime? T_IlisikKesme { get; set; }

        public DateTime? T_EvrakAtama { get; set; }
        public string? AtamaEvrakSayısı { get; set; }
        public Enum_AtamaTuru? AtamaTuru { get; set; }
    }
}
