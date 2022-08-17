using SportStore.Interface;

namespace SportStore.Models

{
    public class DataRepository : IRepository
    {

        private DataContext context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ctx"></param>
        public DataRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Product> Products => context.Products;


        public void AddProduct(Product product)
        {
            this.context.Products.Add(product);
            this.context.SaveChanges();
            Console.WriteLine("Данные успешно сохранены!");
        }


        public Product GetProduct(long key) => context.Products.Find(key);


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
