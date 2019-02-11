using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Data;

namespace catchme.bg.Models
{
    public class SearchViewModel
    {
        //https://stackoverflow.com/questions/40555543/how-do-i-implement-a-checkbox-list-in-asp-net-core
        public List<Profile> Profiles { get; set; }
        public List<CatchmebgUser> Users { get; set; }


        private List<Pets> _pets1;

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

        public List<Filter> PetsFilter
        {
            get;//Pets.Select(u => new Filter() { Id = u.ItemId, Name = u.Name });
            set;
        }

        public class Filter
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }

    }
}
