using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace catchme.bg.Models
{
    /// <summary>
    /// https://odetocode.com/blogs/scott/archive/2013/03/11/dropdownlistfor-with-asp-net-mvc.aspx
    /// </summary>
    public class ProfileViewModel
    {
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
        private List<Weight> _weight1;
        private List<Height> _height1;
        private List<Languages> _languages1;
        private List<Gender> _gender1;
        private List<Age> _age1;
        private List<LookingFor> _lookingFor1;
        private List<MaritalStatus> _maritalStatus1;

        public int ID { set; get; }

        public CatchmebgUser User { get; set; }

        public Profile Profile { get; set; }

        private List<Pets> _pets
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _pets1 = context.Pets.ToList();
                }
                return _pets1;
            }
        }
        private List<Children> _children
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _children1 = context.Children.ToList();
                }
                return _children1;
            }
        }
        private List<Drugs> _drugs
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _drugs1 = context.Drugs.ToList();
                }
                return _drugs1;
            }
            
        }
        private List<Diet> _diet
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _diet1 = context.Diet.ToList();
                }
                return _diet1;
            }
            
        }
        private List<Drinks> _drinks
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _drinks1 = context.Drinks.ToList();
                }
                return _drinks1;
            }
            
        }
        private List<Smokes> _smokes
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _smokes1 = context.Smokes.ToList();
                }
                return _smokes1;
            }
            
        }
        private List<Religion> _religion
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _religion1 = context.Religion.ToList();
                }
                return _religion1;
            }
            
        }
        private List<Ethnicity> _ethnicity        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _ethnicity1 = context.Ethnicity.ToList();
                }
                return _ethnicity1;
            }
            
        }
        private List<Education> _education
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _education1 = context.Education.ToList();
                }
                return _education1;
            }

        }
        private List<HairColor> _hairColor
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _hairColor1 = context.HairColor.ToList();
                }
                return _hairColor1;
            }
            
        }
        private List<EyeColor> _eyeColor
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _eyeColor1 = context.EyeColor.ToList();
                }
                return _eyeColor1;
            }
            
        }
        private List<BodyType> _bodyType
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _bodyType1 = context.BodyType.ToList();
                }
                return _bodyType1;
            }
            
        }
        private List<Weight> _weight
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
        private List<Height> _height
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
        private List<Languages> _languages
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _languages1 = context.Languages.ToList();
                }
                return _languages1;
            }
            
        }
        private List<Gender> _gender
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _gender1 = context.Gender.ToList();
                }
                return _gender1;
            }
            
        }
        private List<Age> _age
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
        private List<LookingFor> _lookingFor
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _lookingFor1 = context.LookingFor.ToList();
                }
                return _lookingFor1;
            }
            
        }
        private List<MaritalStatus> _maritalStatus
        {
            get
            {
                using (CatchmeContext context = new CatchmeContext())
                {
                    _maritalStatus1 = context.MaritalStatus.ToList();
                }
                return _maritalStatus1;
            }
            
        }
        
        public IEnumerable<SelectListItem> PetsItems
        {
            get { return new SelectList(_pets, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> ChildrenItems
        {
            get { return new SelectList(_children, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> DrugsItems
        {
            get { return new SelectList(_drugs, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> DietItems
        {
            get { return new SelectList(_diet, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> DrinksItems
        {
            get { return new SelectList(_drinks, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> SmokesItems
        {
            get { return new SelectList(_smokes, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> ReligionItems
        {
            get { return new SelectList(_religion, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> EthnicityItems
        {
            get { return new SelectList(_ethnicity, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> EducationItems
        {
            get { return new SelectList(_education, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> HairColorItems
        {
            get { return new SelectList(_hairColor, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> EyeColorItems
        {
            get { return new SelectList(_eyeColor, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> BodyTypeItems
        {
            get { return new SelectList(_bodyType, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> WeightItems
        {
            get { return new SelectList(_weight, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> HeightItems
        {
            get { return new SelectList(_height, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> LanguagesItems
        {
            get { return new SelectList(_languages, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> GenderItems
        {
            get { return new SelectList(_gender, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> AgeItems
        {
            get { return new SelectList(_age, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> LookingForItems
        {
            get { return new SelectList(_lookingFor, "Id", "Name"); }
        }

        public IEnumerable<SelectListItem> MaritalStatusItems
        {
            get { return new SelectList(_maritalStatus, "Id", "Name"); }
        }


    }

    
}
