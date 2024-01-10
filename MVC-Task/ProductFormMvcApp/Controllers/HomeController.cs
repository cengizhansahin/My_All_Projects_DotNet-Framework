using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductFormMvcApp.Models;

namespace ProductFormMvcApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(string searchString)
    {
        var products = Repository.Products;
        if (!String.IsNullOrEmpty(searchString))
        {
            products = products.Where(p => p.Name.ToLower().Trim().Contains(searchString)).ToList();
        }
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
