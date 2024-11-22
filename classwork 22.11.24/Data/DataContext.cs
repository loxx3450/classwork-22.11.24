using classwork_22._11._24.Models;
using Microsoft.EntityFrameworkCore;

namespace classwork_22._11._24.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
    }
}
