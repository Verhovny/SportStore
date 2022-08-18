using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Interface;
using System;


namespace SportStore.Controllers
{
    public class HomeController : Controller
    {

        private IRepository repository;
        private ICategoryRepository categoryRepository;

        public HomeController(IRepository repo, ICategoryRepository catrepo) {

            repository = repo;
            categoryRepository = catrepo;
        }

        public IActionResult Index() {
            System.Console.Clear();
            return View(repository.Products.ToArray());
        }


        public ActionResult AddProduct()
        {
            return View("Create");
        }

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


        public IActionResult UpdateProduct(long key)
        {
            ViewBag.Categories = categoryRepository.Categories;
            return View(key == 0 ? new Product() : repository.GetProduct(key));
        }

                
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
