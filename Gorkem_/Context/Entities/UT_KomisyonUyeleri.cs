namespace Gorkem_.Context.Entities
{
    public class UT_KomisyonUyeleri : UTBaseEntity
    {
        public string? TcKimlikNo { get; set; }
        public string? AdSoyad { get; set; }
        public int? Sicil { get; set; }
        public string? GorevUnvani { get; set; }
        public int GorevYeriId { get; set; }
        public virtual KT_GorevYeri? GorevYeri { get; set; }
        public string? Eposta { get; set; }
        public string? CepTelefonu { get; set; }
        public virtual ICollection<UT_Komisyon>? Komisyon { get; set; }


    }
}
