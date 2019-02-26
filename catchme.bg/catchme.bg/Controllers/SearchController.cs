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

            model.AgeFromFilter = !_context.AgeFilter.Any(u => u.FilterUserId == CurrentUser.Id && u.Name == "From") ? new AgeFilter()
                { ItemId = -1, Name = "From", FilterUserId = CurrentUser.Id, Selected = false }
                : _context.AgeFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name=="From");

            model.AgeToFilter = !_context.AgeFilter.Any(u=>u.FilterUserId==CurrentUser.Id && u.Name=="To") ? new AgeFilter()
                    { ItemId = -1, Name = "To", FilterUserId = CurrentUser.Id, Selected = false }
                : _context.AgeFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name == "To");

            model.WeightFromFilter = !_context.WeightFilter.Any(u => u.FilterUserId == CurrentUser.Id && u.Name == "From") ? new WeightFilter()
                    { ItemId = -1, Name = "From", FilterUserId = CurrentUser.Id, Selected = false }
                : _context.WeightFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name == "From");

            model.WeightToFilter = !_context.WeightFilter.Any(u => u.FilterUserId == CurrentUser.Id && u.Name == "To") ? new WeightFilter()
                    { ItemId = -1, Name = "To", FilterUserId = CurrentUser.Id, Selected = false }
                : _context.WeightFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name == "To");

            model.HeightFromFilter = !_context.HeightFilter.Any(u => u.FilterUserId == CurrentUser.Id && u.Name == "From") ? new HeightFilter()
                    { ItemId = -1, Name = "From", FilterUserId = CurrentUser.Id, Selected = false }
                : _context.HeightFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name == "From");

            model.HeightToFilter = !_context.HeightFilter.Any(u => u.FilterUserId == CurrentUser.Id && u.Name == "To") ? new HeightFilter()
                    { ItemId = -1, Name = "To", FilterUserId = CurrentUser.Id, Selected = false }
                : _context.HeightFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name == "To");

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

                var currentAgeFromFilter = _context.AgeFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name=="From");
                if (currentAgeFromFilter == null)
                {
                    _context.AgeFilter.Add(model.AgeFromFilter);
                }
                else
                {
                    currentAgeFromFilter.ItemId = model.AgeFromFilter.ItemId;
                    currentAgeFromFilter.Name = "From";
                    _context.AgeFilter.Update(currentAgeFromFilter);
                }

                var currentAgeToFilter = _context.AgeFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name == "To");
                if (currentAgeToFilter == null)
                {
                    _context.AgeFilter.Add(model.AgeToFilter);
                }
                else
                {
                    currentAgeToFilter.ItemId = model.AgeToFilter.ItemId;
                    currentAgeToFilter.Name = "To";
                    _context.AgeFilter.Update(currentAgeToFilter);
                }

                //---------------------------------------------------------------
                var currentWeightFromFilter = _context.WeightFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name == "From");
                if (currentWeightFromFilter == null)
                {
                    _context.WeightFilter.Add(model.WeightFromFilter);
                }
                else
                {
                    currentWeightFromFilter.ItemId = model.WeightFromFilter.ItemId;
                    currentWeightFromFilter.Name = "From";
                    _context.WeightFilter.Update(currentWeightFromFilter);
                }

                var currentWeightToFilter = _context.WeightFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name == "To");
                if (currentWeightToFilter == null)
                {
                    _context.WeightFilter.Add(model.WeightToFilter);
                }
                else
                {
                    currentWeightToFilter.ItemId = model.WeightToFilter.ItemId;
                    currentWeightToFilter.Name = "To";
                    _context.WeightFilter.Update(currentWeightToFilter);
                }

                var currentHeightFromFilter = _context.HeightFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name == "From");
                if (currentHeightFromFilter == null)
                {
                    _context.HeightFilter.Add(model.HeightFromFilter);
                }
                else
                {
                    currentHeightFromFilter.ItemId = model.HeightFromFilter.ItemId;
                    currentHeightFromFilter.Name = "From";
                    _context.HeightFilter.Update(currentHeightFromFilter);
                }

                var currentHeightToFilter = _context.HeightFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name == "To");
                if (currentHeightToFilter == null)
                {
                    _context.HeightFilter.Add(model.HeightToFilter);
                }
                else
                {
                    currentHeightToFilter.ItemId = model.HeightToFilter.ItemId;
                    currentHeightToFilter.Name = "To";
                    _context.HeightFilter.Update(currentHeightToFilter);
                }
                //---------------------------------------------------------------

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

            if (model.AgeFromFilter != null)
            {
                query = query.Where(u => u.SelectedAge.Value >= model.AgeFromFilter.ItemId).ToList();
            }

            if (model.AgeToFilter != null)
            {
                query = query.Where(u => u.SelectedAge.Value <= model.AgeToFilter.ItemId).ToList();
            }

            if (model.WeightFromFilter != null)
            {
                query = query.Where(u => u.SelectedWeight.Value >= model.WeightFromFilter.ItemId).ToList();
            }

            if (model.WeightToFilter != null)
            {
                query = query.Where(u => u.SelectedWeight.Value <= model.WeightToFilter.ItemId).ToList();
            }

            if (model.HeightFromFilter != null)
            {
                query = query.Where(u => u.SelectedHeight.Value >= model.HeightFromFilter.ItemId).ToList();
            }

            if (model.HeightToFilter != null)
            {
                query = query.Where(u => u.SelectedHeight.Value <= model.HeightToFilter.ItemId).ToList();
            }

            foreach (var item in query)
            {
                model.Users.Add(_bgcontext.Users.FirstOrDefault(u => u.Id == item.ProfileUserId));
            }
        }

    }
}