namespace Gorkem_.Context.Entities
{
    public class UT_KopekKuvveDetay : UTBaseEntity
    {
        public int KopekId { get; set; }
        public virtual UT_Kopek? Kopek { get; set; }

        public string? KuvveNo { get; set; }
        public string? EbysEvrakSayisi { get; set; }
        public string? EbysEvrakTarihi { get; set; }
    }
}
