using BookHouseApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookHouseApp.DataAccess.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
