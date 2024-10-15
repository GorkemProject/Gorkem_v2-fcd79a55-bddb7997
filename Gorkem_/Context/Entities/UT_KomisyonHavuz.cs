namespace Gorkem_.Context.Entities
{
    public class UT_KomisyonHavuz : UTBaseEntity
    {
        public virtual ICollection<UT_Komisyon>? Komisyonlar { get; set; }
    }
}
