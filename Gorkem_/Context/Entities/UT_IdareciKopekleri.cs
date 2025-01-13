namespace Gorkem_.Context.Entities
{
    public class UT_IdareciKopekleri:UTBaseEntity
    {
        
        public int KopekId { get; set; } 
        public UT_Kopek? Kopek { get; set; }
        public int AdayIdareciId { get; set; }
        public UT_AdayIdareci? AdayIdareci { get; set; }
    }
}
