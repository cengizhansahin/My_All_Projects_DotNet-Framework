using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcTask.Models;

namespace MvcTask.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            return View(Repository.Products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryList = Repository.Categories;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            Repository.CreateProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}