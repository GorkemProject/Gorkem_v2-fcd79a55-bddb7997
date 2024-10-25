using System.ComponentModel.DataAnnotations;

namespace Gorkem_.Context.Entities
{
    public class UT_SecimTestiCevap:UTBaseEntity
    {
        public int UtSecimTestId { get; set; }
        public virtual UT_SecimTest UtSecimTest { get; set; }  
        public int SoruId { get; set; }
        public virtual KT_Soru Soru { get; set; }
       
        public int Puan { get; set; }

    }
}
