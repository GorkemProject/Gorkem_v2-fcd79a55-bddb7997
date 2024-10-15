namespace Gorkem_.Context.Entities
{
    public class UT_Komisyon:UTBaseEntity
    {
        public string? KomisyonAdi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public string? GorevYeri { get; set; }
        public virtual ICollection<UT_KomisyonUyeleri>? KomisyonUyeleri { get; set; }

    }
}
