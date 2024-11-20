using System.Reflection.Metadata.Ecma335;

namespace Gorkem_.Context.Entities
{
    public class UT_KursEgitmenler : UTBaseEntity
    {
        public virtual ICollection<UT_Kurs>? Kurslar { get; set; }
        public int Sicil { get; set; }
        public virtual KT_Birim? Birim { get; set; }
        public int? BirimId { get; set; }
        public virtual KT_Rutbe? Rutbe { get; set; }
        public int? RutbeId { get; set; }
        public string? AdSoyad { get; set; }

    }
}
