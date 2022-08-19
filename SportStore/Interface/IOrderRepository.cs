using System.Collections.Generic;
using SportStore.Models;

namespace SportStore.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }

        Order GetOrder(long key);
        
        void AddOrder(Order order);

        void UpdateOrder(Order order);

        void DeleteOrder(Order order);

    }
}
