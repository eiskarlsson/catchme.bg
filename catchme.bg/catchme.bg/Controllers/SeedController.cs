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

        private void SeedOperatingSystemTable()
        {
            var engine = new FileHelperEngine<Question>();

            var webRoot = _env.WebRootPath;
            var filePath = System.IO.Path.Combine(webRoot, "/SeedData/MbtiTest.csv");

            
            // To Read Use:
            var result = engine.ReadFile(filePath);
            // result is now an array of MbtiTest
            using (var context = new CatchmeContext())
            {
                foreach (Question question in result)
                {


                    var dbQuestion = new Question()
                    {
                        ID = question.ID,
                        QuestionText = question.QuestionText,
                        AnswerText1 = question.AnswerText1,
                        AnswerText2 = question.AnswerText2 //,
                        //Language = question.Language
                    };

                    context.Questions.Add(dbQuestion);
                }

                context.SaveChanges();


            }
        }

        public IActionResult Index()
        {
            SeedOperatingSystemTable();


            return View();
        }
    }
}