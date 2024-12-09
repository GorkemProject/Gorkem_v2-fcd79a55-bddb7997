namespace Gorkem_.Context.Entities
{
    public class KT_KursDegerlendirmeSorular :KTBaseEntity
    {
        public int MaxPuan { get; set; }


        //1 Köpekler, 2 Kursiyerler
        public int DegerlendirmeTuru { get; set; }
    }
}
