using Microsoft.EntityFrameworkCore;
using SportStore.Interface;

namespace SportStore.Models

{
    public class DataRepository : IRepository
    {

        private DataContext context;


        public DataRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Product> Products => context.Products.Include(p => p.Category).ToArray();


        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
            Console.WriteLine("Данные успешно сохранены!");
        }


        public Product GetProduct(long key) => context.Products.Include(p => p.Category).First(p => p.Id == key);


        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }


        public void Delete(Product product) 
        { 
            context.Products.Remove(product);
            context.SaveChanges();
        }


            
    }
}
