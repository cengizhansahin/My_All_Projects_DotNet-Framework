using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {

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
                Repository.CreateUser(applyInfo);
                ViewBag.ApplyCount = Repository.Applies.Where(i => i.WillAttend == true).Count();
                return View("Thanks", applyInfo);
            }

            return View(applyInfo);
        }
        public IActionResult List()
        {
            return View(Repository.Applies);
        }
        public IActionResult Thanks()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            return View(Repository.GetById(id));
        }
    }
}