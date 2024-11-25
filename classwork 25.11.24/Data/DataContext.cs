using classwork_25._11._24.Models;
using Microsoft.EntityFrameworkCore;

namespace classwork_25._11._24.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Movie> Movies { get; set; } = default!;
        public DbSet<Showtime> Showtimes { get; set; } = default!;
    }
}
