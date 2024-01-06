using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Apply(string Name,string Phone, string Email, bool WillAttend)
        {
            Console.WriteLine(Name);
            Console.WriteLine(Phone);
            Console.WriteLine(Email);
            Console.WriteLine(WillAttend);
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
    }
}