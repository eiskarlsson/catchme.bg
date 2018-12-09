using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Data;
using catchme.bg.Migrations.Catchme;
using catchme.bg.Models;
using FileHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

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