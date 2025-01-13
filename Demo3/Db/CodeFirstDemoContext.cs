using Demo3.Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo3.Db
{
    public class CodeFirstDemoContext : DbContext
    {
        public CodeFirstDemoContext(DbContextOptions<CodeFirstDemoContext> options) : base(options)
        {
        }
        public DbSet<Player> Players { get; set; }  
        public DbSet<PlayerInstrument> PlayerInstruments { get; set; }  
        public DbSet<InstrumentType> InstrumentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //With one?
            modelBuilder.Entity<Player>().HasMany(p=>p.Instruments).WithOne();

            modelBuilder.Seed();
        }

    }
}
