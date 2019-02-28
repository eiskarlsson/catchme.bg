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

            model.ChildrenFilter = !Context.ChildrenFilter.Any() ? model.Children.Select(u => new ChildrenFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.ChildrenFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.DrugsFilter = !Context.DrugsFilter.Any() ? model.Drugs.Select(u => new DrugsFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.DrugsFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.DietFilter = !Context.DietFilter.Any() ? model.Diet.Select(u => new DietFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.DietFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.DrinksFilter = !Context.DrinksFilter.Any() ? model.Drinks.Select(u => new DrinksFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.DrinksFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.SmokesFilter = !Context.SmokesFilter.Any() ? model.Smokes.Select(u => new SmokesFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.SmokesFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.ReligionFilter = !Context.ReligionFilter.Any() ? model.Religion.Select(u => new ReligionFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.ReligionFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.EthnicityFilter = !Context.EthnicityFilter.Any() ? model.Ethnicity.Select(u => new EthnicityFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.EthnicityFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.EducationFilter = !Context.EducationFilter.Any() ? model.Education.Select(u => new EducationFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.EducationFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.HairColorFilter = !Context.HairColorFilter.Any() ? model.HairColor.Select(u => new HairColorFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.HairColorFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.EyeColorFilter = !Context.EyeColorFilter.Any() ? model.EyeColor.Select(u => new EyeColorFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.EyeColorFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.BodyTypeFilter = !Context.BodyTypeFilter.Any() ? model.BodyType.Select(u => new BodyTypeFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.BodyTypeFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.LanguagesFilter = !Context.LanguagesFilter.Any() ? model.Languages.Select(u => new LanguagesFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.LanguagesFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.GenderFilter = !Context.GenderFilter.Any() ? model.Gender.Select(u => new GenderFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.GenderFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.LookingForFilter = !Context.LookingForFilter.Any() ? model.LookingFor.Select(u => new LookingForFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.LookingForFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

            model.MaritalStatusFilter = !Context.MaritalStatusFilter.Any() ? model.MaritalStatus.Select(u => new MaritalStatusFilter()
                    { ItemId = u.ItemId, Name = u.Name, FilterUserId = CurrentUser.Id, Selected = false }).ToList()
                : Context.MaritalStatusFilter.Where(u => u.FilterUserId == CurrentUser.Id).ToList();

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

                foreach (var genderFilter in model.GenderFilter)
                {
                    var currentGenderFilter = Context.GenderFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == genderFilter.ItemId);
                    if (currentGenderFilter == null)
                    {
                        Context.GenderFilter.Add(genderFilter);
                    }
                    else
                    {
                        currentGenderFilter.Selected = genderFilter.Selected;
                        Context.GenderFilter.Update(currentGenderFilter);
                    }
                }

                foreach (var childrenFilter in model.ChildrenFilter)
                {
                    var currentChildrenFilter = Context.ChildrenFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == childrenFilter.ItemId);
                    if (currentChildrenFilter == null)
                    {
                        Context.ChildrenFilter.Add(childrenFilter);
                    }
                    else
                    {
                        currentChildrenFilter.Selected = childrenFilter.Selected;
                        Context.ChildrenFilter.Update(currentChildrenFilter);
                    }
                }

                foreach (var drugsFilter in model.DrugsFilter)
                {
                    var currentDrugsFilter = Context.DrugsFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == drugsFilter.ItemId);
                    if (currentDrugsFilter == null)
                    {
                        Context.DrugsFilter.Add(drugsFilter);
                    }
                    else
                    {
                        currentDrugsFilter.Selected = drugsFilter.Selected;
                        Context.DrugsFilter.Update(currentDrugsFilter);
                    }
                }

                foreach (var dietFilter in model.DietFilter)
                {
                    var currentDietFilter = Context.DietFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == dietFilter.ItemId);
                    if (currentDietFilter == null)
                    {
                        Context.DietFilter.Add(dietFilter);
                    }
                    else
                    {
                        currentDietFilter.Selected = dietFilter.Selected;
                        Context.DietFilter.Update(currentDietFilter);
                    }
                }

                foreach (var drinksFilter in model.DrinksFilter)
                {
                    var currentDrinksFilter = Context.DrinksFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == drinksFilter.ItemId);
                    if (currentDrinksFilter == null)
                    {
                        Context.DrinksFilter.Add(drinksFilter);
                    }
                    else
                    {
                        currentDrinksFilter.Selected = drinksFilter.Selected;
                        Context.DrinksFilter.Update(currentDrinksFilter);
                    }
                }

                foreach (var smokesFilter in model.SmokesFilter)
                {
                    var currentSmokesFilter = Context.SmokesFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == smokesFilter.ItemId);
                    if (currentSmokesFilter == null)
                    {
                        Context.SmokesFilter.Add(smokesFilter);
                    }
                    else
                    {
                        currentSmokesFilter.Selected = smokesFilter.Selected;
                        Context.SmokesFilter.Update(currentSmokesFilter);
                    }
                }

                foreach (var religionFilter in model.ReligionFilter)
                {
                    var currentReligionFilter = Context.ReligionFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == religionFilter.ItemId);
                    if (currentReligionFilter == null)
                    {
                        Context.ReligionFilter.Add(religionFilter);
                    }
                    else
                    {
                        currentReligionFilter.Selected = religionFilter.Selected;
                        Context.ReligionFilter.Update(currentReligionFilter);
                    }
                }

                foreach (var ethnicityFilter in model.EthnicityFilter)
                {
                    var currentEthnicityFilter = Context.EthnicityFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == ethnicityFilter.ItemId);
                    if (currentEthnicityFilter == null)
                    {
                        Context.EthnicityFilter.Add(ethnicityFilter);
                    }
                    else
                    {
                        currentEthnicityFilter.Selected = ethnicityFilter.Selected;
                        Context.EthnicityFilter.Update(currentEthnicityFilter);
                    }
                }

                foreach (var educationFilter in model.EducationFilter)
                {
                    var currentEducationFilter = Context.EducationFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == educationFilter.ItemId);
                    if (currentEducationFilter == null)
                    {
                        Context.EducationFilter.Add(educationFilter);
                    }
                    else
                    {
                        currentEducationFilter.Selected = educationFilter.Selected;
                        Context.EducationFilter.Update(currentEducationFilter);
                    }
                }

                foreach (var hairColorFilter in model.HairColorFilter)
                {
                    var currentHairColorFilter = Context.HairColorFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == hairColorFilter.ItemId);
                    if (currentHairColorFilter == null)
                    {
                        Context.HairColorFilter.Add(hairColorFilter);
                    }
                    else
                    {
                        currentHairColorFilter.Selected = hairColorFilter.Selected;
                        Context.HairColorFilter.Update(currentHairColorFilter);
                    }
                }

                foreach (var eyeColorFilter in model.EyeColorFilter)
                {
                    var currentEyeColorFilter = Context.EyeColorFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == eyeColorFilter.ItemId);
                    if (currentEyeColorFilter == null)
                    {
                        Context.EyeColorFilter.Add(eyeColorFilter);
                    }
                    else
                    {
                        currentEyeColorFilter.Selected = eyeColorFilter.Selected;
                        Context.EyeColorFilter.Update(currentEyeColorFilter);
                    }
                }

                foreach (var bodyTypeFilter in model.BodyTypeFilter)
                {
                    var currentBodyTypeFilter = Context.BodyTypeFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == bodyTypeFilter.ItemId);
                    if (currentBodyTypeFilter == null)
                    {
                        Context.BodyTypeFilter.Add(bodyTypeFilter);
                    }
                    else
                    {
                        currentBodyTypeFilter.Selected = bodyTypeFilter.Selected;
                        Context.BodyTypeFilter.Update(currentBodyTypeFilter);
                    }
                }

                foreach (var languagesFilter in model.LanguagesFilter)
                {
                    var currentLanguagesFilter = Context.LanguagesFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == languagesFilter.ItemId);
                    if (currentLanguagesFilter == null)
                    {
                        Context.LanguagesFilter.Add(languagesFilter);
                    }
                    else
                    {
                        currentLanguagesFilter.Selected = languagesFilter.Selected;
                        Context.LanguagesFilter.Update(currentLanguagesFilter);
                    }
                }

                foreach (var lookingForFilter in model.LookingForFilter)
                {
                    var currentLookingForFilter = Context.LookingForFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == lookingForFilter.ItemId);
                    if (currentLookingForFilter == null)
                    {
                        Context.LookingForFilter.Add(lookingForFilter);
                    }
                    else
                    {
                        currentLookingForFilter.Selected = lookingForFilter.Selected;
                        Context.LookingForFilter.Update(currentLookingForFilter);
                    }
                }

                foreach (var maritalStatusFilter in model.MaritalStatusFilter)
                {
                    var currentMaritalStatusFilter = Context.MaritalStatusFilter.FirstOrDefault(u =>
                        u.FilterUserId == CurrentUser.Id && u.ItemId == maritalStatusFilter.ItemId);
                    if (currentMaritalStatusFilter == null)
                    {
                        Context.MaritalStatusFilter.Add(maritalStatusFilter);
                    }
                    else
                    {
                        currentMaritalStatusFilter.Selected = maritalStatusFilter.Selected;
                        Context.MaritalStatusFilter.Update(currentMaritalStatusFilter);
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

            if (model.ChildrenFilter.Any(u => u.Selected))
            {

                foreach (var item in model.ChildrenFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedChildren.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.DrugsFilter.Any(u => u.Selected))
            {

                foreach (var item in model.DrugsFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedDrugs.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.DietFilter.Any(u => u.Selected))
            {

                foreach (var item in model.DietFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedDiet.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.DrinksFilter.Any(u => u.Selected))
            {

                foreach (var item in model.DrinksFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedDrinks.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.SmokesFilter.Any(u => u.Selected))
            {

                foreach (var item in model.SmokesFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedSmokes.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.ReligionFilter.Any(u => u.Selected))
            {

                foreach (var item in model.ReligionFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedReligion.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.EthnicityFilter.Any(u => u.Selected))
            {

                foreach (var item in model.EthnicityFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedEthnicity.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.EducationFilter.Any(u => u.Selected))
            {

                foreach (var item in model.EducationFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedEducation.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.HairColorFilter.Any(u => u.Selected))
            {

                foreach (var item in model.HairColorFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedHairColor.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.EyeColorFilter.Any(u => u.Selected))
            {

                foreach (var item in model.EyeColorFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedEyeColor.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.BodyTypeFilter.Any(u => u.Selected))
            {

                foreach (var item in model.BodyTypeFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedBodyType.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.LanguagesFilter.Any(u => u.Selected))
            {

                foreach (var item in model.LanguagesFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedLanguages.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.GenderFilter.Any(u => u.Selected))
            {

                foreach (var item in model.GenderFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedGender.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.LookingForFilter.Any(u => u.Selected))
            {

                foreach (var item in model.LookingForFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedLookingFor.Value == item.ItemId).ToList();
                    }
                }
            }

            if (model.MaritalStatusFilter.Any(u => u.Selected))
            {

                foreach (var item in model.MaritalStatusFilter)
                {
                    if (item.Selected)
                    {
                        query = Context.Profiles.Where(u => u.SelectedMaritalStatus.Value == item.ItemId).ToList();
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