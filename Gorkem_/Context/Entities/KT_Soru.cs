namespace Gorkem_.Context.Entities
{
    public class KT_Soru : KTBaseEntity
    {
        public int Puan { get; set; }

        public int SecimTestId { get; set; }
        public virtual KT_SecimTest SecimTest { get; set; } 
    }
}
