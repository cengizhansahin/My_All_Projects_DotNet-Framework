using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcbasics.Models;

namespace mvcbasics.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var kurs = new Course();
            kurs.Id = 1;
            kurs.Title = "AspNet Core 7.0";
            kurs.Description = "Keyifli sardı";
            kurs.Image = "1.png";
            return View(kurs);
        }
        public IActionResult List()
        {
            return View(Repository.Courses);
        }
        public IActionResult Details(int id)
        {
            var kurs = Repository.GetCourseById(id);
            return View(kurs);
        }
    }
}