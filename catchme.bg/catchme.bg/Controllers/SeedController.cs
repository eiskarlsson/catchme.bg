using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using catchme.bg.Data;
using catchme.bg.Migrations.Catchme;
using catchme.bg.Models;
using Microsoft.AspNetCore.Mvc;

namespace catchme.bg.Controllers
{
    public class SeedController : Controller
    {

        static void SeedOperatingSystemTable()
        {
            using (var context = new CatchmeContext())
            {
                var question1 = new Question
                {
                    ID = 1,
                    QuestionText = "Abcdefghijklmnopqrstuvwxyz",
                    Answers = new List<Answer>()
                    {
                        new Answer() {ID = 1, AnswerText = "a"}, new Answer() {ID = 1, AnswerText = "b"}

                    }
                };

                context.Questions.Add(question1);
            }
        }

        public IActionResult Index()
        {
            SeedOperatingSystemTable();


            return View();
        }
    }
}