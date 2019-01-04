using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Data;
using catchme.bg.Models;
using Microsoft.AspNetCore.Mvc;

namespace catchme.bg.Controllers
{
    public class ProfileController : Controller
    {
        public catchmebgContext _bgcontext { get; set; }

        public CatchmeContext _context { get; set; }

        protected ProfileViewModel ProfileViewModel { get; set; }

        protected CatchmebgUser CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                }

                return userId != null ? _bgcontext.Users.FirstOrDefault(x => x.Id == userId) : null;
            }
            set => _currentUser = value;
        }

        protected string userId;
        private CatchmebgUser _currentUser;

        public ProfileController(catchmebgContext bgcontext, CatchmeContext context)
        {
            _bgcontext = bgcontext;
            _context = context;
        }


        public IActionResult Index()
        {
            var model = new ProfileViewModel();
            model.User = CurrentUser;
            model.Profile = new Profile();
            model.Profile.DateCreated = DateTime.Now;
            model.Profile.DateLastChange = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ProfileViewModel model)
        {
            model.Profile.DateCreated = DateTime.Now;
            model.Profile.DateLastChange = DateTime.Now;
            if (ModelState.IsValid)
            {
            }

            return View(model);
        }
    }
}