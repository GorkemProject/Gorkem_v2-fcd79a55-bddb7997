using System.ComponentModel.DataAnnotations.Schema;

namespace Gorkem_.Context.Entities
{
    public class UT_Kopek_SatinAlma
    {
        [ForeignKey("Id")]

        public int Id { get; set; }
        public string? AdiSoyadi { get; set; }
        public string? Adresi { get; set; }
        public int TelefonNumarasi { get; set; }
        public DateTime SatinAlmaTarihi { get; set; }


    }
}
