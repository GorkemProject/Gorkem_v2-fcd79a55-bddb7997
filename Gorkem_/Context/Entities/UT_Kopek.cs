﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Gorkem_.Context.Entities
{
    public class UT_Kopek : UTBaseEntity
    {

        public int IrkId { get; set; } 
        public virtual KT_Irk? Irk { get; set; }

        public int BirimRef { get; set; }
        [ForeignKey(nameof(BirimRef))]
        public virtual KT_Birim? BIRIM { get; set; }
        public int BransRef { get; set; }
        [ForeignKey(nameof(BransRef))]
        public virtual KT_Brans? BRANS { get; set; }

        public int KuvveNumarasi { get; set; }
        public int CipNumarasi { get; set; }

        public int CinsRef { get; set; }
        [ForeignKey(nameof(CinsRef))]
        public virtual KT_Cins? CINS { get; set; }


        public DateTime DogumTarihi { get; set; }
        public string? YapilanIslem { get; set; }
        public string? NihaiKanaat { get; set; }

        public int KopekTuruRef { get; set; }
        [ForeignKey(nameof(KopekTuruRef))]
        public virtual KT_KopekTuru? KOPEKTURU { get; set; }

        public bool Karar { get; set; }

        public int DurumRef { get; set; }
        [ForeignKey(nameof(DurumRef))]
        public virtual KT_KopekDurumu? DURUM { get; set; }

        public string? TeminSekli { get; set; }

        //Relationship
        public virtual UT_Kopek_Hibe? Hibe { get; set; }
        public virtual UT_Kopek_SatinAlma? SatinAlma { get; set; }
        public virtual UT_Kopek_Uretim? URETİM { get; set; }
    }
}
