using Microsoft.EntityFrameworkCore;

namespace CorePoker.Data
{
    public class CorePokerContext : DbContext
    {
        public CorePokerContext(DbContextOptions<CorePokerContext> options) : base(options)
        {
        }

        public DbSet<Table> Tables { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().HasIndex(p => new {p.PublicId}).IsUnique();
            modelBuilder.Entity<Table>().HasIndex(p => new { p.Name }).IsUnique();

            modelBuilder.Entity<Player>().HasIndex(e => e.Nickname).IsUnique();

            modelBuilder.Entity<TablePlayer>().HasKey(e => new { e.TableId, e.PlayerId });
        }
    }
}
