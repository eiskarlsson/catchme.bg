using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Models;
using Microsoft.AspNetCore.Mvc;

namespace catchme.bg.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            var model = new SearchViewModel();
            return View(model);
        }
    }
}