﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Data;
using catchme.bg.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using X.PagedList;
using static catchme.bg.Models.SearchViewModel;

//https://stackoverflow.com/questions/39212140/how-can-i-pass-some-objects-in-viewbag-to-the-action-preserve-search-sort-an/39215048#39215048

namespace catchme.bg.Controllers
{
    public class SearchController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public catchmebgContext _bgcontext { get; set; }

        public CatchmeContext _context { get; set; }

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



            foreach (var item in model.Profiles)
            {
                model.Users.Add(_bgcontext.Users.FirstOrDefault(u => u.Id == item.ProfileUserId));
            }

            model.PetsFilter = model.Pets.Select(u => new Filter() { Id = u.ItemId, Name = u.Name, Selected = false }).ToList();

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

                if (model.PetsFilter.Any(u => u.Selected))
                {
                    model.Profiles.Clear();
                    foreach (var item in model.PetsFilter)
                    {
                        if (item.Selected)
                        {
                            model.Profiles.AddRange(_context.Profiles.Where(u => u.SelectedPets.Value == item.Id));
                        }
                    }
                }

                if (model.PetsFilter.Any(u => u.Selected))
                {
                    model.Users.Clear();
                }

                foreach (var item in model.Profiles)
                {
                    model.Users.Add(_bgcontext.Users.FirstOrDefault(u => u.Id == item.ProfileUserId));
                }
            }

            var pageNumber = page ?? 1;

            model.OnePageOfUsers = model.Users.ToPagedList(pageNumber, 2);

            return View(model);
        }


    }
}