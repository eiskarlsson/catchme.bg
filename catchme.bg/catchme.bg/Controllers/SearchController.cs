﻿using System;
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

        public catchmebgContext Bgcontext { get; set; }

        public CatchmeContext Context { get; set; }

        protected CatchmebgUser CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                }

                return UserId != null ? Bgcontext.Users.FirstOrDefault(x => x.Id == UserId) : null;
            }
            set => _currentUser = value;
        }

        protected string UserId;
        private CatchmebgUser _currentUser;

        public SearchController(catchmebgContext bgcontext, CatchmeContext context, IHostingEnvironment environment)
        {
            Bgcontext = bgcontext;
            Context = context;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index(int? page)
        {
            var model = new SearchViewModel();

            model.Profiles = Context.Profiles.ToList();

            model.Users = new List<CatchmebgUser>();

            model.PetsFilter = !Context.PetsFilter.Any() ? model.Pets.Select(u => new PetsFilter()
                { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected=false}).ToList() 
                : Context.PetsFilter.Where(u=>u.FilterUserId==CurrentUser.Id).ToList();

            model.AgeFromFilter = !Context.AgeFilter.Any(u => u.FilterUserId == CurrentUser.Id && u.Name == "From") ? new AgeFilter()
                { ItemId = -1, Name = "From", FilterUserId = CurrentUser.Id, Selected = false }
                : Context.AgeFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name=="From");

            model.AgeToFilter = !Context.AgeFilter.Any(u=>u.FilterUserId==CurrentUser.Id && u.Name=="To") ? new AgeFilter()
                    { ItemId = -1, Name = "To", FilterUserId = CurrentUser.Id, Selected = false }
                : Context.AgeFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name == "To");

            model.WeightFromFilter = !Context.WeightFilter.Any(u => u.FilterUserId == CurrentUser.Id && u.Name == "From") ? new WeightFilter()
                    { ItemId = -1, Name = "From", FilterUserId = CurrentUser.Id, Selected = false }
                : Context.WeightFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name == "From");

            model.WeightToFilter = !Context.WeightFilter.Any(u => u.FilterUserId == CurrentUser.Id && u.Name == "To") ? new WeightFilter()
                    { ItemId = -1, Name = "To", FilterUserId = CurrentUser.Id, Selected = false }
                : Context.WeightFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name == "To");

            model.HeightFromFilter = !Context.HeightFilter.Any(u => u.FilterUserId == CurrentUser.Id && u.Name == "From") ? new HeightFilter()
                    { ItemId = -1, Name = "From", FilterUserId = CurrentUser.Id, Selected = false }
                : Context.HeightFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name == "From");

            model.HeightToFilter = !Context.HeightFilter.Any(u => u.FilterUserId == CurrentUser.Id && u.Name == "To") ? new HeightFilter()
                    { ItemId = -1, Name = "To", FilterUserId = CurrentUser.Id, Selected = false }
                : Context.HeightFilter.FirstOrDefault(u => u.FilterUserId == CurrentUser.Id && u.Name == "To");

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
                model.Profiles = Context.Profiles.ToList();

                FilterUsers(model);

                var currentAgeFromFilter = Context.AgeFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name=="From");
                if (currentAgeFromFilter == null)
                {
                    Context.AgeFilter.Add(model.AgeFromFilter);
                }
                else
                {
                    currentAgeFromFilter.ItemId = model.AgeFromFilter.ItemId;
                    currentAgeFromFilter.Name = "From";
                    Context.AgeFilter.Update(currentAgeFromFilter);
                }

                var currentAgeToFilter = Context.AgeFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name == "To");
                if (currentAgeToFilter == null)
                {
                    Context.AgeFilter.Add(model.AgeToFilter);
                }
                else
                {
                    currentAgeToFilter.ItemId = model.AgeToFilter.ItemId;
                    currentAgeToFilter.Name = "To";
                    Context.AgeFilter.Update(currentAgeToFilter);
                }

                //---------------------------------------------------------------
                var currentWeightFromFilter = Context.WeightFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name == "From");
                if (currentWeightFromFilter == null)
                {
                    Context.WeightFilter.Add(model.WeightFromFilter);
                }
                else
                {
                    currentWeightFromFilter.ItemId = model.WeightFromFilter.ItemId;
                    currentWeightFromFilter.Name = "From";
                    Context.WeightFilter.Update(currentWeightFromFilter);
                }

                var currentWeightToFilter = Context.WeightFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name == "To");
                if (currentWeightToFilter == null)
                {
                    Context.WeightFilter.Add(model.WeightToFilter);
                }
                else
                {
                    currentWeightToFilter.ItemId = model.WeightToFilter.ItemId;
                    currentWeightToFilter.Name = "To";
                    Context.WeightFilter.Update(currentWeightToFilter);
                }

                var currentHeightFromFilter = Context.HeightFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name == "From");
                if (currentHeightFromFilter == null)
                {
                    Context.HeightFilter.Add(model.HeightFromFilter);
                }
                else
                {
                    currentHeightFromFilter.ItemId = model.HeightFromFilter.ItemId;
                    currentHeightFromFilter.Name = "From";
                    Context.HeightFilter.Update(currentHeightFromFilter);
                }

                var currentHeightToFilter = Context.HeightFilter.FirstOrDefault(u =>
                    u.FilterUserId == CurrentUser.Id && u.Name == "To");
                if (currentHeightToFilter == null)
                {
                    Context.HeightFilter.Add(model.HeightToFilter);
                }
                else
                {
                    currentHeightToFilter.ItemId = model.HeightToFilter.ItemId;
                    currentHeightToFilter.Name = "To";
                    Context.HeightFilter.Update(currentHeightToFilter);
                }
                //---------------------------------------------------------------

                foreach (var petsFilter in model.PetsFilter)
                {
                    var currentPetsFilter = Context.PetsFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == petsFilter.ItemId);
                    if (currentPetsFilter==null)
                    {
                        Context.PetsFilter.Add(petsFilter);
                    }
                    else
                    {
                        currentPetsFilter.Selected = petsFilter.Selected;
                        Context.PetsFilter.Update(currentPetsFilter);
                    }
                }
                
                Context.SaveChanges();
                
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
                        query = Context.Profiles.Where(u => u.SelectedPets.Value == item.ItemId).ToList();
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
                model.Users.Add(Bgcontext.Users.FirstOrDefault(u => u.Id == item.ProfileUserId));
            }
        }

    }
}