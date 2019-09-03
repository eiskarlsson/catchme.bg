using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace catchme.bg.Areas.Legal.Controllers
{
    [Area("Legal")]
    public class HomeController : Controller
    {
        public IActionResult PrivacyPolicy()
        {
            return View();
        }

        public IActionResult DataProtection()
        {
            return View();
        }
    }
}