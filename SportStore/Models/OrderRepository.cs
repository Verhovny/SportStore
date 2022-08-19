﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

using SportStore.Interface;

namespace SportStore.Models

{
    public class OrderRepository : IOrderRepository
    {

        private DataContext context;

        public OrderRepository(DataContext ctx) => context = ctx;

        public IEnumerable<Order> Orders => context.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);

        public Order GetOrder(long key) => context.Orders.Include(o => o.Lines).First(o => o.Id == key);

        public void AddOrder(Order order)
        {
            this.context.Orders.Add(order);
            this.context.SaveChanges();
            Console.WriteLine("Данные успешно сохранены!");
        }

        public void UpdateOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }

        public void DeleteOrder(Order order) 
        { 
            context.Orders.Remove(order);
            context.SaveChanges();
        }


            
    }
}
