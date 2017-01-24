using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CorePoker.Data
{
    public class CorePokerContext : DbContext
    {
        public CorePokerContext(DbContextOptions<CorePokerContext> options) : base(options)
        {
        }

        public DbSet<Table> Tables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>().HasIndex(p => new {p.PublicId}).IsUnique();
        }
    }

    public class Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    

        [Required]
        [MaxLength(36)]
        public string PublicId { get; set; }
    }
}
