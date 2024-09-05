using Gorkem_.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Context
{
    public class GorkemDbContext : DbContext
    {

        public GorkemDbContext(DbContextOptions<GorkemDbContext> options):base(options) { } 
      
        public DbSet<KT_Birim> KT_Birims { get; set; }
        public DbSet<KT_Brans> KT_Branss { get; set; }
        public DbSet<KT_IdareciDurum> KT_IdareciDurum { get; set; }
        public DbSet<KT_Irk> KT_Irks { get; set; }
        public DbSet<KT_Cins> KT_Cinss { get; set; }
        public DbSet<KT_KopekTuru> KT_KopekTurus { get; set; }
        public DbSet<UT_Kopek_Hibe> UT_Kopek_Hibes { get; set; }
        public DbSet<UT_Kopek> UT_Kopek_Kopeks { get; set; }
        public DbSet<UT_Kopek_SatinAlma> UT_Kopek_SatinAlmas { get; set; }
        public DbSet<UT_Kopek_Uretim> UT_Kopek_Uretims { get; set; }
        public DbSet<UT_Idareci> UT_Idarecis { get; set; }
        public DbSet<KT_Askerlik> KT_Askerliks { get; set; }
        public DbSet<KT_Rutbe> KT_Rutbes  { get; set; }
        public DbSet<KT_KopekDurumu> KT_KopekDurumus   { get; set; }
        public DbSet<KT_OgrenimDurumu> KT_OgrenimDurumus { get; set; }
        public DbSet<KT_YabanciDil> KT_YabanciDils { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
