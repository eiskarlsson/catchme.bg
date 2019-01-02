using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Data;
using catchme.bg.Migrations.Catchme;
using catchme.bg.Models;
using FileHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace catchme.bg.Controllers
{
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
                var firstQuestion = context.Questions.FirstOrDefault(u => u.ID == 1 && u.Language == "en");
                var lastQuestion = context.Questions.FirstOrDefault(u => u.ID == 140 && u.Language == "bg");
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

        private async void ClearData()
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
                await context.SaveChangesAsync();
            }
        }

        //private async void SeedTable(DbSet<IProfileItem> tableDbSet, List<string> values)
        //{
        //    using (CatchmeContext context = new CatchmeContext())
        //    {
        //        foreach (var item in values)
        //        {
        //            IProfileItem instance = Activator.CreateInstance<IProfileItem>();
        //            instance.Name = item;
        //            tableDbSet.Add(instance);
        //        }

        //        await context.SaveChangesAsync();
        //    }
        //}

        private async void SeedTables()
        {
            
           await SeedTable(new Age(), new List<string>() { });
           await SeedTable(new BodyType(), new List<string>() { });
           await SeedTable(new Children(), new List<string>() { });
           await SeedTable(new Diet(), new List<string>() { });
           await SeedTable(new Drinks(), new List<string>() { });
           await SeedTable(new Drugs(), new List<string>() { });
           await SeedTable(new Education(), new List<string>() { });
           await SeedTable(new Ethnicity(), new List<string>() { });
           await SeedTable(new EyeColor(), new List<string>() { });
           await SeedTable(new Gender(), new List<string>() { });
           await SeedTable(new HairColor(), new List<string>() { });
           await SeedTable(new Height(), new List<string>() { });
           await SeedTable(new Languages(), new List<string>() { });
           await SeedTable(new LookingFor(), new List<string>() { });
           await SeedTable(new MaritalStatus(), new List<string>() { });
           await SeedTable(new Pets(), new List<string>() { });
           await SeedTable(new Religion(), new List<string>() { });
           await SeedTable(new Smokes(), new List<string>() { });
           await SeedTable(new Weight(), new List<string>() { });

        }

        private async Task SeedTable(Age age, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    age.Name = item;
                    context.Age.Add(age);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(BodyType bodyType, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    bodyType.Name = item;
                    context.BodyType.Add(bodyType);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Children children, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    children.Name = item;
                    context.Children.Add(children);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Diet diet, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    diet.Name = item;
                    context.Diet.Add(diet);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Drinks drinks, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    drinks.Name = item;
                    context.Drinks.Add(drinks);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Drugs drugs, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    drugs.Name = item;
                    context.Drugs.Add(drugs);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Education education, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    education.Name = item;
                    context.Education.Add(education);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Ethnicity ethnicity, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    ethnicity.Name = item;
                    context.Ethnicity.Add(ethnicity);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(EyeColor eyeColor, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    eyeColor.Name = item;
                    context.EyeColor.Add(eyeColor);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Gender gender, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    gender.Name = item;
                    context.Gender.Add(gender);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(HairColor hairColor, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    hairColor.Name = item;
                    context.HairColor.Add(hairColor);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Height height, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    height.Name = item;
                    context.Height.Add(height);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Languages languages, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    languages.Name = item;
                    context.Languages.Add(languages);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(LookingFor lookingFor, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    lookingFor.Name = item;
                    context.LookingFor.Add(lookingFor);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(MaritalStatus maritalStatus, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    maritalStatus.Name = item;
                    context.MaritalStatus.Add(maritalStatus);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Pets pets, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    pets.Name = item;
                    context.Pets.Add(pets);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Religion religion, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    religion.Name = item;
                    context.Religion.Add(religion);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Smokes smokes, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    smokes.Name = item;
                    context.Smokes.Add(smokes);
                }

                await context.SaveChangesAsync();
            }
        }

        private async Task SeedTable(Weight weight, List<string> list)
        {
            using (CatchmeContext context = new CatchmeContext())
            {
                foreach (var item in list)
                {
                    weight.Name = item;
                    context.Weight.Add(weight);
                }

                await context.SaveChangesAsync();
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

            try
            {
                textValue = SeedMbtiTable();
            }
            catch (Exception ex)
            {
                textValue = ex.Message;
            }

            // redirect to our Index action passing the new label value
            return RedirectToAction("Index", "Seed", new { label = textValue });
        }
    }
}