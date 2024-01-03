using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcbasics.Models;

namespace mvcbasics.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
}
