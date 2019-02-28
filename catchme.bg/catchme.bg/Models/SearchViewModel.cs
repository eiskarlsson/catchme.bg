using System;
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
        private List<Children> _children1;
        private List<Drugs> _drugs1;
        private List<Diet> _diet1;
        private List<Drinks> _drinks1;
        private List<Smokes> _smokes1;
        private List<Religion> _religion1;
        private List<Ethnicity> _ethnicity1;
        private List<Education> _education1;
        private List<HairColor> _hairColor1;
        private List<EyeColor> _eyeColor1;
        private List<BodyType> _bodyType1;
        private List<Age> _age1;
        private List<Weight> _weight1;
        private List<Height> _height1;
        private List<Languages> _languages1;
        private List<Gender> _gender1;
        private List<LookingFor> _lookingFor1;
        private List<MaritalStatus> _maritalStatus1;

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

        //----------------------------------------------------------
        public List<Children> Children
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _children1 = context.Children.OrderBy(x => x.ItemId).ToList();
                }
                return _children1;
            }
        }
        public List<Drugs> Drugs
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _drugs1 = context.Drugs.OrderBy(x => x.ItemId).ToList();
                }
                return _drugs1;
            }

        }
        public List<Diet> Diet
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _diet1 = context.Diet.OrderBy(x => x.ItemId).ToList();
                }
                return _diet1;
            }

        }
        public List<Drinks> Drinks
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _drinks1 = context.Drinks.OrderBy(x => x.ItemId).ToList();
                }
                return _drinks1;
            }

        }
        public List<Smokes> Smokes
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _smokes1 = context.Smokes.OrderBy(x => x.ItemId).ToList();
                }
                return _smokes1;
            }

        }
        public List<Religion> Religion
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _religion1 = context.Religion.OrderBy(x => x.ItemId).ToList();
                }
                return _religion1;
            }

        }
        public List<Ethnicity> Ethnicity
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _ethnicity1 = context.Ethnicity.OrderBy(x => x.ItemId).ToList();
                }
                return _ethnicity1;
            }

        }
        public List<Education> Education
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _education1 = context.Education.OrderBy(x => x.ItemId).ToList();
                }
                return _education1;
            }

        }
        public List<HairColor> HairColor
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _hairColor1 = context.HairColor.OrderBy(x => x.ItemId).ToList();
                }
                return _hairColor1;
            }

        }
        public List<EyeColor> EyeColor
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _eyeColor1 = context.EyeColor.OrderBy(x => x.ItemId).ToList();
                }
                return _eyeColor1;
            }

        }
        public List<BodyType> BodyType
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _bodyType1 = context.BodyType.OrderBy(x => x.ItemId).ToList();
                }
                return _bodyType1;
            }

        }

        public List<Languages> Languages
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _languages1 = context.Languages.OrderBy(x => x.ItemId).ToList();
                }
                return _languages1;
            }

        }
        public List<Gender> Gender
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _gender1 = context.Gender.OrderBy(x => x.ItemId).ToList();
                }
                return _gender1;
            }

        }

        public List<LookingFor> LookingFor
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _lookingFor1 = context.LookingFor.OrderBy(x => x.ItemId).ToList();
                }
                return _lookingFor1;
            }

        }
        public List<MaritalStatus> MaritalStatus
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _maritalStatus1 = context.MaritalStatus.OrderBy(x => x.ItemId).ToList();
                }
                return _maritalStatus1;
            }

        }
        //-----------------------------------------------------------

        public List<Age> Age
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

        public List<Weight> Weight
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _weight1 = context.Weight.OrderBy(x => int.Parse(x.Name)).ToList();
                }
                return _weight1;
            }

        }
        public List<Height> Height
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _height1 = context.Height.OrderBy(x => int.Parse(x.Name)).ToList();
                }
                return _height1;
            }

        }

        public List<PetsFilter> PetsFilter
        {
            get;
            set;
        }

        public AgeFilter AgeFromFilter { get; set; }

        public AgeFilter AgeToFilter { get; set; }

        public HeightFilter HeightFromFilter { get; set; }

        public HeightFilter HeightToFilter { get; set; }

        public WeightFilter WeightFromFilter { get; set; }

        public WeightFilter WeightToFilter { get; set; }

        public List<ChildrenFilter> ChildrenFilter { get; set; }

        public List<DrugsFilter> DrugsFilter { get; set; }

        public List<DietFilter> DietFilter { get; set; }

        public List<DrinksFilter> DrinksFilter { get; set; }

        public List<SmokesFilter> SmokesFilter { get; set; }

        public List<ReligionFilter> ReligionFilter { get; set; }

        public List<EthnicityFilter> EthnicityFilter { get; set; }

        public List<EducationFilter> EducationFilter { get; set; }

        public List<HairColorFilter> HairColorFilter { get; set; }

        public List<EyeColorFilter> EyeColorFilter { get; set; }

        public List<BodyTypeFilter> BodyTypeFilter { get; set; }

        public List<LanguagesFilter> LanguagesFilter { get; set; }

        public List<GenderFilter> GenderFilter { get; set; }

        public List<LookingForFilter> LookingForFilter { get; set; }

        public List<MaritalStatusFilter> MaritalStatusFilter { get; set; }




        public IEnumerable<SelectListItem> AgeItems => new SelectList(Age, "ItemId", "Name");

        public IEnumerable<SelectListItem> WeightItems => new SelectList(Weight, "ItemId", "Name");

        public IEnumerable<SelectListItem> HeightItems => new SelectList(Height, "ItemId", "Name");

    }
}
