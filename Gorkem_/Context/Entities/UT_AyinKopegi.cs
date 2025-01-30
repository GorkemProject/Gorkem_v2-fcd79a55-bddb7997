namespace Gorkem_.Context.Entities
{
    public class UT_AyinKopegi : UTBaseEntity
    {

        public int KopekId { get; set; }
        public virtual UT_Kopek? Kopek { get; set; }
    }
}
