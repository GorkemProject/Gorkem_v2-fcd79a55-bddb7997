using Gorkem_.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Context
{
    public class GorkemDbContext : DbContext
    {

        public GorkemDbContext(DbContextOptions<GorkemDbContext> options):base(options) { } 
      
        public DbSet<KT_Birim> KT_Birims { get; set; }
        public DbSet<KT_Brans> KT_Branss { get; set; }
        public DbSet<KT_Durum> KT_Durums { get; set; }
        public DbSet<KT_Irk> KT_Irks { get; set; }
        public DbSet<KT_Cins> KT_Cinss { get; set; }
        public DbSet<KT_KopekTuru> KT_KopekTurus { get; set; }
        public DbSet<UT_Kopek_Hibe> UT_Kopek_Hibes { get; set; }
        public DbSet<UT_Kopek_Kopek> UT_Kopek_Kopeks { get; set; }
        public DbSet<UT_Kopek_SatinAlma> UT_Kopek_SatinAlmas { get; set; }
        public DbSet<UT_Kopek_Uretim> UT_Kopek_Uretims { get; set; }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
