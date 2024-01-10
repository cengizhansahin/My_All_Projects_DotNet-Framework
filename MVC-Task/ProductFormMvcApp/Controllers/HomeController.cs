using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductFormMvcApp.Models;

namespace ProductFormMvcApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(Repository.Products);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
