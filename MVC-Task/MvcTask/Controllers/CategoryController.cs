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
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.Categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            Repository.CreateCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}