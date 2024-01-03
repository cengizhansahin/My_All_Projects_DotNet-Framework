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
            var kurslar = new List<Course>{
                new Course(){
                    Id=1,
                    Title="AspNet Core",
                    Description="Güzel keyifli bir kurs",
                    Image = "2.png"
                },
                new Course(){
                    Id=2,
                    Title="ReactJs",
                    Description="Seri, hızlı bir kurs",
                    Image="1.png"
                },
                new Course(){
                    Id=3,
                    Title="Redux Toolkit",
                    Description="Güzerl keyifli bir kurs",
                    Image="4.jpg"
                }
            };
            return View(kurslar);
        }
    }
}