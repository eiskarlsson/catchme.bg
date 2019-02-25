using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Data;
using catchme.bg.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using X.PagedList;
using static catchme.bg.Models.SearchViewModel;

//https://stackoverflow.com/questions/39212140/how-can-i-pass-some-objects-in-viewbag-to-the-action-preserve-search-sort-an/39215048#39215048

namespace catchme.bg.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public catchmebgContext _bgcontext { get; set; }

        public CatchmeContext _context { get; set; }

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

        public SearchController(catchmebgContext bgcontext, CatchmeContext context, IHostingEnvironment environment)
        {
            _bgcontext = bgcontext;
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            var model = new SearchViewModel();

            model.Profiles = _context.Profiles.ToList();

            model.Users = new List<CatchmebgUser>();

            model.PetsFilter = !_context.PetsFilter.Any() ? model.Pets.Select(u => new PetsFilter()
                { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected=false}).ToList() 
                : _context.PetsFilter.Where(u=>u.FilterUserId==CurrentUser.Id).ToList();

            model.AgeFilter = !_context.AgeFilter.Any() ? new AgeFilter()
                { ItemId = 0, Name = "Select Age", FilterUserId = CurrentUser.Id, Selected = false }
                : _context.AgeFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id);

            FilterUsers(model);
            
            var pageNumber = page ?? 1;

            model.OnePageOfUsers = model.Users.ToPagedList(pageNumber, 2);

            return View(model);
        }

        [HttpPost]
        public IActionResult Index([Bind] SearchViewModel model, int? page)
        {
            if (ModelState.IsValid)
            {
                model.Profiles = _context.Profiles.ToList();

                FilterUsers(model);

                var currentAgeFilter = _context.AgeFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.ItemId == model.AgeFilter.ItemId);
                if (currentAgeFilter == null)
                {
                    _context.AgeFilter.Add(model.AgeFilter);
                }
                else
                {
                    currentAgeFilter.ItemId = model.AgeFilter.ItemId;
                    _context.AgeFilter.Update(currentAgeFilter);
                }

                foreach (var petsFilter in model.PetsFilter)
                {
                    var currentPetsFilter = _context.PetsFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == petsFilter.ItemId);
                    if (currentPetsFilter==null)
                    {
                        _context.PetsFilter.Add(petsFilter);
                    }
                    else
                    {
                        currentPetsFilter.Selected = petsFilter.Selected;
                        _context.PetsFilter.Update(currentPetsFilter);
                    }
                }
                
                _context.SaveChanges();
                
            }

            var pageNumber = page ?? 1;

            model.OnePageOfUsers = model.Users.ToPagedList(pageNumber, 2);

            return View(model);
        }

        //private void FilterUsers(SearchViewModel model)
        //{
        //    if (model.PetsFilter.Any(u => u.Selected))
        //    {
        //        model.Profiles.Clear();
        //        foreach (var item in model.PetsFilter)
        //        {
        //            if (item.Selected)
        //            {
        //                model.Profiles.AddRange(_context.Profiles.Where(u => u.SelectedPets.Value == item.ItemId));
        //            }
        //        }
        //    }

        //    if(model.AgeFilter != null)
        //    {
        //        model.Profiles.AddRange(_context.Profiles.Where(u => u.SelectedAge.Value == model.AgeFilter.ItemId));
        //    }

        //    foreach (var item in model.Profiles)
        //    {
        //        model.Users.Add(_bgcontext.Users.FirstOrDefault(u => u.Id == item.ProfileUserId));
        //    }
        //}

        private void FilterUsers(SearchViewModel model)
        {
            var query = model.Profiles;
            if (model.PetsFilter.Any(u => u.Selected))
            {
                
                foreach (var item in model.PetsFilter)
                {
                    if (item.Selected)
                    {
                        query = _context.Profiles.Where(u => u.SelectedPets.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.AgeFilter != null)
            {
                query = query.Where(u => u.SelectedAge.Value == model.AgeFilter.ItemId).ToList();
            }

            foreach (var item in query)
            {
                model.Users.Add(_bgcontext.Users.FirstOrDefault(u => u.Id == item.ProfileUserId));
            }
        }

    }
}