using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcTask.Models;

namespace MvcTask.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
