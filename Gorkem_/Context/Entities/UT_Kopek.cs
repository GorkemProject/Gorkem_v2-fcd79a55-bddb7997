using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gorkem_.Context.Entities
{
    public class UT_Kopek : UTBaseEntity
    {
        public string KopekAdi { get; set; } = string.Empty;
        public int IrkId { get; set; }
        public virtual KT_Irk? Irk { get; set; }
        public int BransId { get; set; }
        public virtual KT_Brans? Brans { get; set; }
        public string? KuvveNumarasi { get; set; }
        public string? CipNumarasi { get; set; }
        public int KadroIlId { get; set; }
        public virtual KT_KadroIl? KadroIl { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string? YapilanIslem { get; set; }
        public string? NihaiKanaat { get; set; }
        
        public int KararId { get; set; }
        public virtual KT_Karar Karar { get; set; }
        public virtual ICollection<UT_IdareciKopekleri>? Idareci { get; set; }

        public int EdinimSekli { get; set; } //Uretim=1,Satinalma=2,Hibe=3

        public int EdinimTabloId { get; set; }


        //ilk kayıtta kullanılmayacak alanlar


        //public int CinsId { get; set; }
        //public virtual KT_Cins? Cins { get; set; }
        //public int KopekDurumId { get; set; }
        //public virtual KT_KopekDurumu? Durum { get; set; }
        //public int TeminSekli { get; set; }
        //Relationship
        //public virtual UT_Kopek_Hibe? Hibe { get; set; }
        //public virtual UT_Kopek_SatinAlma? SatinAlma { get; set; }
        //public virtual UT_Kopek_Uretim? URETİM { get; set; } 

    }
}
