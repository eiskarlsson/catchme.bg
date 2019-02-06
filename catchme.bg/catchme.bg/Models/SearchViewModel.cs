using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Data;

namespace catchme.bg.Models
{
    public class SearchViewModel
    {
        //https://stackoverflow.com/questions/40555543/how-do-i-implement-a-checkbox-list-in-asp-net-core

        private List<Pets> _pets1;
        private IEnumerable<Filter> _petsFilter;

        private List<Pets> _pets
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

        public IEnumerable<Filter> PetsFilter
        {
            get => _pets.Select(u=> new Filter(){ Id=u.ItemId, Name = u.Name, Selected = false});
            set => _petsFilter = value;
        }

        public class Filter
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Selected { get; set; }
        }

    }
}
