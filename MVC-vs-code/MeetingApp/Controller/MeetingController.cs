using MeetingApp.Models;
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
        public IActionResult Apply(ApplyInfo applyInfo)
        {
            if (ModelState.IsValid)
            {
                Repository.Applies.Add(applyInfo);
                return RedirectToAction("List");
            }
            // Console.WriteLine(applyInfo.Name);
            // Console.WriteLine(applyInfo.Phone);
            // Console.WriteLine(applyInfo.Email);
            // Console.WriteLine(applyInfo.WillAttend);
            return View(applyInfo);
        }
        public IActionResult List()
        {
            return View(Repository.Applies);
        }
    }
}