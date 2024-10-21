namespace Gorkem_.Context.Entities
{
    public class UT_Komisyon:UTBaseEntity
    {
        public string? KomisyonAdi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public int GorevYeriId { get; set; }
        public virtual KT_GorevYeri? GorevYeri { get; set; }
        public virtual ICollection<UT_KomisyonUyeleri>? KomisyonUyeleri { get; set; }

    }
}
