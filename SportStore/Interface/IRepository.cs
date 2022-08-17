using System.Collections.Generic;
using SportStore.Models;

namespace SportStore.Interface
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product product);

        Product GetProduct(long key);

        void UpdateProduct(Product product);

        void Delete(Product product);

    }
}
