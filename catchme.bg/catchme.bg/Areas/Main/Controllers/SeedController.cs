using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Data;
//using catchme.bg.Migrations.Catchme;
using catchme.bg.Models;
using FileHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace catchme.bg.Controllers
{
    [Area("Main")]
    public class SeedController : Controller
    {
        private IHostingEnvironment _env;
        public SeedController(IHostingEnvironment env)
        {
            _env = env;
        }

        private string SeedMbtiTable()
        {
            var engine = new FileHelperEngine<Question>();

            var contentRoot = _env.ContentRootPath;
            var filePath = System.IO.Path.Combine(contentRoot, "SeedData/MbtiTest.csv");


            // To Read Use:
            var result = engine.ReadFile(filePath);
            // result is now an array of MbtiTest
            using (CatchmeContext context = new CatchmeContext())
            {
                var firstQuestion = context.Questions.FirstOrDefault(u => u.Id == 1 && u.Language == "en");
                var lastQuestion = context.Questions.FirstOrDefault(u => u.Id == 140 && u.Language == "bg");
                if (firstQuestion != null && lastQuestion != null)
                {
                    return "Db seeded already!";
                }
                else
                {
                    foreach (Question question in result)
                    {


                        var dbQuestion = new Question()
                        {
                            QuestionID = question.QuestionID,
                            QuestionText = question.QuestionText,
                            AnswerText1 = question.AnswerText1,
                            AnswerText2 = question.AnswerText2,
                            Language = question.Language
                        };

                        context.Questions.Add(dbQuestion);
                        //context.DetachLocal(dbQuestion, dbQuestion.ID.ToString());
                    }

                    context.SaveChanges();
                    return "Db has been seeded!";
                }



            }
        }

        private void ClearData()
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                context.Age.Clear();
                context.BodyType.Clear();
                context.Children.Clear();
                context.Diet.Clear();
                context.Drinks.Clear();
                context.Drugs.Clear();
                context.Education.Clear();
                context.Ethnicity.Clear();
                context.EyeColor.Clear();
                context.Gender.Clear();
                context.HairColor.Clear();
                context.Height.Clear();
                context.Languages.Clear();
                context.LookingFor.Clear();
                context.MaritalStatus.Clear();
                context.Pets.Clear();
                context.Religion.Clear();
                context.Smokes.Clear();
                context.Weight.Clear();
                context.SaveChanges();
            }
        }

        private string SeedTables()
        {
            
           SeedAge(Enumerable.Range(18,100).Select(i => i.ToString()).OrderBy(x => x, new SemiNumericComparer()).ToList<string>());
           SeedBodyType(new List<string>() { "Slim", "Normal", "Heavy Set" });
           SeedChildren(new List<string>() { "No Children", "Doesn't want children", "Wants children", "Has children"});
           SeedDiet(new List<string>() { "No diet", "On a diet" });
           SeedDrinks(new List<string>() { "Doesn't drink", "Drinks socially", "Heavy drinker" });
           SeedDrugs(new List<string>() { "Drugs", "No drugs"});
           SeedEducation(new List<string>() { "High School", "Some College", "Bachelor's Degree", "Graduate Degree and above" });
           SeedEthnicity(new List<string>() { "White", "Asian", "Black", "Other"});
           SeedEyeColor(new List<string>() { "Brown", "Blue", "Green", "Red" });
           SeedGender(new List<string>() { "Woman", "Man", "Transgender" });
           SeedHairColor(new List<string>() { "Brown", "Black", "Blonde", "Red", "Grey" });
           SeedHeight(Enumerable.Range(10, 300).Select(i => i.ToString()).ToList<string>());
           SeedLanguages(new List<string>() { "One", "Two", "Three", "More than three" });
           SeedLookingFor(new List<string>() { "Woman", "Man", "Couple" });
           SeedMaritalStatus(new List<string>() { "Single", "Divorced", "Married" });
           SeedPets(new List<string>() { "No pets", "Doesn't want pets", "Wants pets", "Has pets" });
           SeedReligion(new List<string>() { "Doesn't believe", "Believer", "Christian", "Buddhist", "Muslim", "Taoist", "Judaist", "Other" });
           SeedSmokes(new List<string>() { "Smokes", "Doesn't smoke" });
           SeedWeight(Enumerable.Range(10, 300).Select(i => i.ToString()).ToList<string>());
           return "Profile Tables Seeded!";
        }

        private void SeedAge(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var age = new Age();
                    age.Name = item;
                    age.ItemId = i;
                    context.Age.Add(age);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedBodyType(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var bodyType = new BodyType();
                    bodyType.Name = item;
                    bodyType.ItemId = i;
                    context.BodyType.Add(bodyType);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedChildren(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var children = new Children();
                    children.Name = item;
                    children.ItemId = i;
                    context.Children.Add(children);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedDiet(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var diet = new Diet();
                    diet.Name = item;
                    diet.ItemId = i;
                    context.Diet.Add(diet);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedDrinks(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var drinks = new Drinks();
                    drinks.Name = item;
                    drinks.ItemId = i;
                    context.Drinks.Add(drinks);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedDrugs(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var drugs = new Drugs();
                    drugs.Name = item;
                    drugs.ItemId = i;
                    context.Drugs.Add(drugs);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedEducation(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var education = new Education();
                    education.Name = item;
                    education.ItemId = i;
                    context.Education.Add(education);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedEthnicity(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var ethnicity = new Ethnicity();
                    ethnicity.Name = item;
                    ethnicity.ItemId = i;
                    context.Ethnicity.Add(ethnicity);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedEyeColor(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var eyeColor = new EyeColor();
                    eyeColor.Name = item;
                    eyeColor.ItemId = i;
                    context.EyeColor.Add(eyeColor);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedGender(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var gender = new Gender();
                    gender.Name = item;
                    gender.ItemId = i;
                    context.Gender.Add(gender);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedHairColor(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var hairColor = new HairColor();
                    hairColor.Name = item;
                    hairColor.ItemId = i;
                    context.HairColor.Add(hairColor);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedHeight(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var height = new Height();
                    height.Name = item;
                    height.ItemId = i;
                    context.Height.Add(height);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedLanguages(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var languages = new Languages();
                    languages.Name = item;
                    languages.ItemId = i;
                    context.Languages.Add(languages);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedLookingFor(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var lookingFor = new LookingFor();
                    lookingFor.Name = item;
                    lookingFor.ItemId = i;
                    context.LookingFor.Add(lookingFor);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedMaritalStatus(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var maritalStatus = new MaritalStatus();
                    maritalStatus.Name = item;
                    maritalStatus.ItemId = i;
                    context.MaritalStatus.Add(maritalStatus);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedPets(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var pets = new Pets();
                    pets.Name = item;
                    pets.ItemId = i;
                    context.Pets.Add(pets);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedReligion(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var religion = new Religion();
                    religion.Name = item;
                    religion.ItemId = i;
                    context.Religion.Add(religion);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedSmokes(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var smokes = new Smokes();
                    smokes.Name = item;
                    smokes.ItemId = i;
                    context.Smokes.Add(smokes);
                    i++;
                }

                context.SaveChanges();
            }
        }

        private void SeedWeight(List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                var i = 0;
                foreach (var item in list)
                {
                    var weight = new Weight();
                    weight.Name = item;
                    weight.ItemId = i;
                    context.Weight.Add(weight);
                    i++;
                }

                context.SaveChanges();
            }
        }

        public IActionResult Index(string label)
        {
            // pass label value into view
            return View("Index", label ?? "");
        }

        [HttpPost]
        public ActionResult Index()
        {
            var textValue = String.Empty;
            var textValue1 = String.Empty;

            try
            {
                textValue = SeedMbtiTable();
                ClearData();
                textValue1 =  SeedTables();
            }
            catch (Exception ex)
            {
                textValue = ex.Message;
            }

            // redirect to our Index action passing the new label value
            return RedirectToAction("Index", "Seed", new { label = textValue+ " " + textValue1 });
        }

        public class SemiNumericComparer : IComparer<string>
        {
            public int Compare(string s1, string s2)
            {
                if (IsNumeric(s1) && IsNumeric(s2))
                {
                    if (Convert.ToInt32(s1) > Convert.ToInt32(s2)) return 1;
                    if (Convert.ToInt32(s1) < Convert.ToInt32(s2)) return -1;
                    if (Convert.ToInt32(s1) == Convert.ToInt32(s2)) return 0;
                }

                if (IsNumeric(s1) && !IsNumeric(s2))
                    return -1;

                if (!IsNumeric(s1) && IsNumeric(s2))
                    return 1;

                return string.Compare(s1, s2, true);
            }

            public static bool IsNumeric(object value)
            {
                try
                {
                    int i = Convert.ToInt32(value.ToString());
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
        }
    }
}