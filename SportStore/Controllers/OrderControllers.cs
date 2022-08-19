using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Interface;
using System;


namespace SportStore.Controllers
{
    public class OrderController : Controller
    {

        private IRepository productRepository;
        private IOrderRepository orderRepository;



        public OrderController(IRepository productRepo, IOrderRepository orderRepo)
        {
            productRepository = productRepo;
            orderRepository = orderRepo;
        }

        public IActionResult Index() {
            //System.Console.Clear();
            return View(orderRepository.Orders);
        }


        public IActionResult EditOrder(long id)
        {
            var products = productRepository.Products;

            Order order = (id == 0 ? new Order() : orderRepository.GetOrder(id));

            IDictionary<long, OrderLine> linesMap = order.Lines?.ToDictionary(l => l.ProductId)
                ?? new Dictionary<long, OrderLine>();


            ViewBag.Lines = products.Select(p => linesMap.ContainsKey(p.Id) ? linesMap[p.Id] : new OrderLine { Product = p, ProductId = p.Id, Quantity = 0 });

            return View(order);
        }

        [HttpPost]
        public IActionResult AddOrUpdateOrder(Order order)
        {

            order.Lines = order.Lines.Where(l => l.Id > 0 || (l.Id == 0 && l.Quantity > 0)).ToArray();

            if (order.Id == 0)
            {
                orderRepository.AddOrder(order);
            }
            else
            {
                orderRepository.UpdateOrder(order);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult DeleteOrder(Order order)
        {
            orderRepository.DeleteOrder(order);

            return RedirectToAction(nameof(Index));
        }


    }
}
