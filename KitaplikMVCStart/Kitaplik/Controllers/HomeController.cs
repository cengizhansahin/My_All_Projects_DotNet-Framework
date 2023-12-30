using Kitaplik.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kitaplik.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //bunlar bizim interafce lerimiz. metodun sonunda yazdığımız bizim action nımız olacak ve bize o action ait view sayfasının döndürecek.
        //get ve post olmak üzere iki durumda da nasıl davranacağını belirleyebiliyoruz.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
