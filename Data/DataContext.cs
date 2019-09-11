using CapstoneCompanion.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneCompanion.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Hymn> Hymns { get; set; }
    }
}