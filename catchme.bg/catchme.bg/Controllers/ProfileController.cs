using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Models;
using Microsoft.AspNetCore.Mvc;

namespace catchme.bg.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            var model = new ProfileViewModel();
            return View(model);
        }
    }
}