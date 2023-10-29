using FeiraConnect.Model;
using Microsoft.EntityFrameworkCore;

namespace FeiraConnect.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Feira>().ToTable("tb_feira");

        }

        public DbSet<Feira> Feiras { get; set; } = null!;
    }
}
