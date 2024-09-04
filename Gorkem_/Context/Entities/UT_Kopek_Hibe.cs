using System.ComponentModel.DataAnnotations.Schema;

namespace Gorkem_.Context.Entities
{
    public class UT_Kopek_Hibe
    {
        [ForeignKey("Id")]
        public int Id { get; set; }
        public string? AdiSoyadi { get; set; }
        public string? Adresi { get; set; }
        public int TelefonNumarasi { get; set; }
        public DateTime HibeEdilmeTarihi { get; set; }
        public int KopekKopekId { get; set; }
        public ICollection<UT_Kopek>? UT_Kopek_Kopek { get; set; }
    }
}
