using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace mvcbasics.Controllers
{
    [Route("[controller]")]
    public class CourseController : Controller
    {
        public string Index()
        {
            return "course/index";
        }
        public string List()
        {
            return "course/list";
        }
    }
}