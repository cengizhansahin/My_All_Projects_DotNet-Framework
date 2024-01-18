using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVC_efCoreApp.Controllers
{
    [Route("[controller]")]
    public class KursKayitController : Controller
    {
        
        
        public IActionResult Index()
        {
            return View();
        }        
    }
}