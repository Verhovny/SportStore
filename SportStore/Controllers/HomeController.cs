using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Interface;
using System;


namespace SportStore.Controllers
{
    public class HomeController : Controller
    {

        private IRepository repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public HomeController(IRepository repo) => repository = repo;






        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() {
            System.Console.Clear();
            return View(repository.Products.ToArray());
        }





        /// <summary>
        /// Форма добавления продуктаы
        /// </summary>
        /// <returns></returns>
        public ActionResult AddProduct()
        {
            return View("Create");
        }





        /// <summary>
        /// Добавление продвкта
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                //return BadRequest();
                repository.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View("Create", product);
        }


        /// <summary>
        /// Форма редактирования
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IActionResult UpdateProduct(long key)
        {
            return View(key == 0 ? new Product() : repository.GetProduct(key));
        }

        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {

            if (ModelState.IsValid)
            {
                if (product.Id == 0)
                {
                  repository.AddProduct(product);
                }
                else
                {
                    repository.UpdateProduct(product);
                }
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }



        [HttpPost]
        public IActionResult Delete(Product product)
        {
            repository.Delete(product);
            return RedirectToAction(nameof(Index));
        }


    }
}
