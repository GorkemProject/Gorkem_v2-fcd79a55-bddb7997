using System.Reflection.Metadata.Ecma335;
using Gorkem_.Enums;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Context.Entities
{
    public class UT_AdayIdareci : UTBaseEntity
    {
        public int Sicil { get; set; }
        public string AdSoyad { get; set; } = string.Empty;
        public string CepTelefonu { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; }

        public int IdareciDurumId { get; set; }
        public KT_IdareciDurum? IdareciDurum { get; set; }

        public int KadroIlId { get; set; }
        public KT_KadroIl? KadroIl { get; set; } 

        public int BransId { get; set; }
        public KT_Brans? Brans { get; set; }

        public int RutbeId { get; set; }
        public KT_Rutbe? Rutbe { get; set; }

        public int AskerlikId { get; set; }
        public KT_Askerlik? Askerlik { get; set; }

        public List<KT_OgrenimDurumu>? OgrenimDurumu { get; set; } = new();
        public List<KT_YabanciDil>? YabanciDil { get; set; } = new();
        public int Puan { get; set; }
        public Enum_AdayPersonelDurum Durum { get; set; }
        public virtual UT_KursEgitmenler TestiYapan { get; set; }
        public int TestiYapanId { get; set; }
        public DateTime TestTarihi { get; set; }


    }
}
