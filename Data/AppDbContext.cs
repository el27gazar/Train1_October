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
        public DbSet<Category> categories { get; set; }

        // Seed initial data for Categories
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Clothing" },
                new Category { Id = 4, Name = "Cars" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
