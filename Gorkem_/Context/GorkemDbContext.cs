using Gorkem_.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gorkem_.Context
{
    public class GorkemDbContext : DbContext
    {

        public GorkemDbContext(DbContextOptions<GorkemDbContext> options):base(options) { } 
      
        public DbSet<KT_Birim> Birims { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
