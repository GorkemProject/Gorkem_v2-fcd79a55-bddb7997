namespace Gorkem_.Context.Entities
{
    public class UT_Kursiyer : UTBaseEntity
    {
        public virtual UT_Idareci? Idareci { get; set; }
        public int IdareciId { get; set; }
        public virtual ICollection<UT_Kurs>? Kurslar { get; set; }

    }
}
