using BookSeries.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookSeries.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<BookCollection> BookCollections { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
