﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace catchme.bg.Models
{
    public class SearchViewModel
    {
        //https://stackoverflow.com/questions/40555543/how-do-i-implement-a-checkbox-list-in-asp-net-core
        public List<Profile> Profiles { get; set; }
        public List<CatchmebgUser> Users { get; set; }
        public int? Page { get; set; }

        public IPagedList<CatchmebgUser> OnePageOfUsers { get; set; }


        private List<Pets> _pets1;
        private List<Age> _age1;

        public List<Pets> Pets
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _pets1 = context.Pets.OrderBy(x => x.ItemId).ToList();
                }
                return _pets1;
            }
        }

        public List<Age> _age
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _age1 = context.Age.OrderBy(x => int.Parse(x.Name)).ToList();
                }
                return _age1;
            }

        }

        public List<PetsFilter> PetsFilter
        {
            get;//Pets.Select(u => new Filter() { Id = u.ItemId, Name = u.Name });
            set;
        }

        public AgeFilter AgeFilter { get; set; }

        public IEnumerable<SelectListItem> AgeItems => new SelectList(_age, "ItemId", "Name");

    }
}
