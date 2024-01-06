using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers

{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            // var greeting = saat > 12 ? "İyi günler" : "Günaydın";
            // ViewBag.Selamlama = saat>12?"İyi günler":"Günaydın";
            // ViewBag.Username = "Cengizhan";
            ViewData["Selamlama"] = saat > 12 ? "İyi Günlerss" : "Günaydınss";
            ViewData["Username"] = "Cengizhan";

            var meetingInfo = new MeetingInfo()
            {
                Id = 1,
                Location = "İstanbu, Abc Kongre Merkezi",
                Date = new DateTime(2024, 01, 20, 20, 0, 0),
                NumberOfPeople = 100
            };
            return View(meetingInfo);
        }
    }
}