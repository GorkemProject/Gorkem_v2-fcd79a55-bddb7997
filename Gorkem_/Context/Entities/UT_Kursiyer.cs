namespace Gorkem_.Context.Entities
{
    public class UT_Kursiyer : UTBaseEntity
    {
        public int Sicil { get; set; }

        public string? PersonelAdi { get; set; }

        public int KopekId { get; set; }
        public virtual UT_Kopek? Kopek { get; set; }
        public string? CipNumarası { get; set; }

        public int KursId { get; set; }
        public virtual UT_Kurs Kurs { get; set; }



    }
}
