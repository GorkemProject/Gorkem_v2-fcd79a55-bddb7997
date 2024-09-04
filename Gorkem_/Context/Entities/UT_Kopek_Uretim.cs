using System.ComponentModel.DataAnnotations.Schema;

namespace Gorkem_.Context.Entities
{
    public class UT_Kopek_Uretim
    {
        [ForeignKey("Id")]

        public int Id { get; set; }
        public string? KopekRef { get; set; }
        public string? AnneKopekRef { get; set; }
        public string? BabaKopekRef { get; set; }

        public int KopekKopekId { get; set; }
        public ICollection<UT_Kopek>? UT_Kopek_Kopek { get; set; }
    }
}
