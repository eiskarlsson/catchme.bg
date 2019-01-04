using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Data;
using catchme.bg.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace catchme.bg.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
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
            //https://docs.microsoft.com/en-gb/ef/core/querying/related-data
            //var currentProfile = (from u in _context.Profiles.Include(u=>u.ProfileUser) where (u.ProfileUser.Id == CurrentUser.Id) select u).FirstOrDefault();
            var currentProfile = (from u in _context.Profiles where (u.ProfileUser.Id == CurrentUser.Id) select u).FirstOrDefault();
            
            if (currentProfile != null)
            {
                model.Profile = currentProfile;
            }
            else
            {
                model.ProfileUser = CurrentUser;
                model.Profile = new Profile();
            }
            
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Index(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentProfile = _context.Profiles.FirstOrDefault(u => u.ProfileUser.Id == CurrentUser.Id);
                if (currentProfile != null)
                {
                    model.Profile.DateLastChange = DateTime.Now;
                    _context.Profiles.Update(model.Profile);
                }
                else
                {
                    model.ProfileUser = CurrentUser;
                    model.Profile.ProfileUser = CurrentUser;
                    model.Profile.DateCreated = DateTime.Now;
                    model.Profile.DateLastChange = DateTime.Now;
                    _context.Profiles.Add(model.Profile);
                }
                
                _context.SaveChanges();
            }

            return View(model);
        }
    }
}