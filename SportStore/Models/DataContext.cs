using Microsoft.EntityFrameworkCore;

namespace SportStore.Models

{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
             : base(options)
        {
            // Database.EnsureCreated();
        }



        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }





    }
}
