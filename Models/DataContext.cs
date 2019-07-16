using Microsoft.EntityFrameworkCore;

namespace BookNS.Models
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasMany<Rating>(m => m.Ratings)
            .WithOne(r => r.Book).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Book>().HasOne<Publisher>(m => m.Publisher)
            .WithMany(s => s.Books).OnDelete(DeleteBehavior.SetNull);
        }
    }
}