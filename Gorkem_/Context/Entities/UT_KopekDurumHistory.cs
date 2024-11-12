namespace Gorkem_.Context.Entities
{
    public class UT_KopekDurumHistory : UTBaseEntity
    {
        public int KopekId { get; set; }
        public virtual UT_Kopek Kopek { get; set; }
        public int KopekDurum { get; set; }

    }
}
