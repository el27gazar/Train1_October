using Microsoft.EntityFrameworkCore;
using Train1_October.Models;

namespace Train1_October.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Item> items { get; set; }
    }
}
