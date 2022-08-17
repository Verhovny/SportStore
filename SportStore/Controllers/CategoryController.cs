using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Interface;
using System;


namespace SportStore.Controllers
{
    public class CategoryController : Controller
    {

        private ICategoryRepository repository;


        public CategoryController(ICategoryRepository repo) => repository = repo;


        public IActionResult Index() {
            //System.Console.Clear();
            return View(repository.Categories.ToArray());
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            repository.AddCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(long id)
        {

            ViewBag.EditId = id;
            return View("Index", repository.Categories);
        }



        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            repository.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            repository.DeleteCategory(category);
            return RedirectToAction("Index");
        }


    }
}
