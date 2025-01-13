namespace Gorkem_.Context.Entities
{
    public class UT_Idareci : UTBaseEntity
    {
        public virtual UT_AdayIdareci? Idareci { get; set; }
        public int IdareciId { get; set; }
        public string? EbysEvrakTarihi { get; set; }
        public string? EbysEvrakSayisi { get; set; }
        

    }
}
