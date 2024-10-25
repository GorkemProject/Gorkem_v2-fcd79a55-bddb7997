using Gorkem_.Enums;

namespace Gorkem_.Context.Entities
{
    public class UT_SecimTest : UTBaseEntity
    {
        public virtual UT_Kopek Kopek { get; set; }
        public int KopekId { get; set; }

        public virtual UT_Idareci Idareci { get; set; }
        public int IdareciId { get; set; }

        public int SecimTestId { get; set; }
        public virtual KT_SecimTest SecimTest { get; set; }

        public virtual KT_GorevYeri SinavYeri { get; set; }
        public int SinavYeriId { get; set; }

        public DateTime Tarih { get; set; }

        public bool TepkiSekli { get; set; }
        public bool Havlama { get; set; }
        public Enum_SecimTestBrans SecimTestBrans { get; set; }
        public string Degerlendirme { get; set; }

        public string TestKomisyonu { get; set; }
        public int  ToplamPuan { get; set; }
    }
}
