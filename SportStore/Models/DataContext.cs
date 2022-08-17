using Microsoft.EntityFrameworkCore;

namespace SportStore.Models

{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        public DataContext(DbContextOptions<DataContext> options)
             : base(options)
        {
            // Database.EnsureCreated();
        }

    }
}
