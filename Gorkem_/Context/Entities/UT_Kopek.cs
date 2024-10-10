using Gorkem_.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
        public virtual KT_Karar? Karar { get; set; }
        public virtual ICollection<UT_IdareciKopekleri>? Idareci { get; set; }
        public Enum_Cinsiyet Cinsiyet { get; set; }
        public  Enum_TeminSekli EdinimSekli { get; set; }
       

        public int? BabaKopekId { get; set; }
        
        [ForeignKey("BabaKopekId")]
        public virtual UT_Kopek? BabaKopek { get; set; }
        public int? AnneKopekId { get; set; }
        
        
        [ForeignKey("AnneKopekId")]
        public virtual UT_Kopek? AnneKopek { get; set; }

        public string? EdinilenKisi { get; set; }
        public string? EdinilenKisiAdres { get; set; }
        public string? EdinilenKisiTelefon { get; set; }
        public DateTime? EdinilmeTarihi { get; set; }




        //public int EdinimSekli { get; set; } //Uretim=1,Satinalma=2,Hibe=3

        //public int EdinimTabloId { get; set; }


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
