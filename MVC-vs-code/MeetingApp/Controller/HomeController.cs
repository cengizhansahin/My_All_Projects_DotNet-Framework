using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers

{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            // var greeting = saat > 12 ? "İyi günler" : "Günaydın";
            ViewBag.Selamlama = saat>12?"İyi günler":"Günaydın";
            return View();
        }
    }
}