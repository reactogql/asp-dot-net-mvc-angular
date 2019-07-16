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
    }
}