using Gorkem_.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Context
{
    public class GorkemDbContext : DbContext
    {

        public GorkemDbContext(DbContextOptions<GorkemDbContext> options):base(options) { } 
      
        public DbSet<KT_Karar> KT_Karars { get; set; }
        public DbSet<KT_KadroIl> KT_KadroIls { get; set; }
        public DbSet<KT_Brans> KT_Branss { get; set; }
        public DbSet<KT_IdareciDurum> KT_IdareciDurum { get; set; }
        public DbSet<KT_Irk> KT_Irks { get; set; }
        public DbSet<KT_Cins> KT_Cinss { get; set; }
        public DbSet<UT_Kopek> UT_Kopek_Kopeks { get; set; }
        public DbSet<UT_AdayIdareci> UT_AdayIdareci { get; set; }
        public DbSet<UT_Idareci> UT_Idarecis { get; set; }
        public DbSet<UT_IdareciKopekleri> UT_IdareciKopekleri { get; set; }
        public DbSet<KT_Askerlik> KT_Askerliks { get; set; }
        public DbSet<KT_Rutbe> KT_Rutbes  { get; set; }
        public DbSet<KT_KopekDurumu> KT_KopekDurumus   { get; set; }
        public DbSet<KT_OgrenimDurumu> KT_OgrenimDurumus { get; set; }
        public DbSet<KT_YabanciDil> KT_YabanciDils { get; set; }   
        public DbSet<UT_Komisyon> UT_Komisyons { get; set; }
        public DbSet<UT_KomisyonUyeleri> UT_KomisyonUyeleris { get; set; }
        public DbSet<KT_GorevYeri> KT_GorevYeris { get; set; }
        public DbSet<KT_Soru> KT_Sorus { get; set; }
        public DbSet<KT_SecimTest> KT_SecimTests { get; set; }
        public DbSet<UT_SecimTest> UT_SecimTests { get; set; }
        public DbSet<UT_SecimTestiCevap> UT_SecimTestiCevaplar { get; set; }
        //public DbSet<KT_FiiliBirim> KT_FiiliBirims { get; set; }
        public DbSet<UT_KopekCalKad> UT_KopekCalKads { get; set; }
        public DbSet<KT_Birim> KT_Birims { get; set; }
        public DbSet<UT_KopekDurumHistory> UT_KopekDurumHistory { get; set; }
        public DbSet<KT_KursEgitimListesi> KT_KursEgitimListesis{ get; set; }
        public DbSet<KT_KursMufredat> KT_KursMufredats{ get; set; }
        public DbSet<UT_Kurs> UT_Kurs   { get; set; }
        public DbSet<UT_KursEgitmenler> UT_KursEgitmenler  { get; set; }
        public DbSet<UT_Kursiyer> UT_Kursiyer  { get; set; }
        public DbSet<UT_KursGunlukRapor> UT_KursGunlukRapors  { get; set; }
        public DbSet<UT_KursGunlukRaporDersler> UT_KursGunlukRaporDersler  { get; set; }
        //public DbSet<UT_KursHaftalıkDegerlendirmeRaporu> UT_KursHaftalıkDegerlendirmeRaporus  { get; set; }
        public DbSet<UT_HaftalıkDegerlendirmeRaporuGozlemler> UT_HaftalıkDegerlendirmeRaporuGozlemlers  { get; set; }

        public DbSet<KT_KursDegerlendirmeSorular> KT_KursDegerlendirmeSorular { get; set; }
        public DbSet<UT_KursDegerlendirmeCevap> UT_KursDegerlendirmeCevap { get; set; }
        public DbSet<UT_KopekVeIdareciDegerlendirmeFormu> UT_KopekVeIdareciDegerlendirmeFormu { get; set; }

        public DbSet<UT_KopekKuvveDetay> UT_KopekKuvveDetays { get; set; }

        //public DbSet<KT_KursKopekDegerlendirmeSorular> KT_KursKopekDegerlendirmeSorular { get; set; }
        //public DbSet<UT_KursKopekDegerlendirmeCevap> UT_KursKopekDegerlendirmeCevap { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          

            base.OnModelCreating(modelBuilder);
        }

    }
}
