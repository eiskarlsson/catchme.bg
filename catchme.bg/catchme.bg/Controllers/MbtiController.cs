using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Data;
using catchme.bg.Models;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
/// <summary>
/// Based on the SO Question: https://stackoverflow.com/questions/12844763/getting-a-list-of-radio-button-values-in-asp-mvc-3/12845534#12845534
/// </summary>

namespace catchme.bg.Controllers
{
    [Authorize]
    public class MbtiController : Controller
    {
        public catchmebgContext _bgcontext { get; set; }

        public CatchmeContext _context { get; set; }

        protected Evaluation Eval { get; set; }

        protected CatchmebgUser CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                }

                return userId != null ? _bgcontext.Users.FirstOrDefault(x => x.Id == userId) : null;
            }
            set { _currentUser = value; }
        }

        protected string userId;
        private CatchmebgUser _currentUser;

        public MbtiController(catchmebgContext bgcontext, CatchmeContext context)
        {
            _bgcontext = bgcontext;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new Evaluation()
            {
                UserName = CurrentUser.UserName,
                Questions = _context.Questions.Where(u => u.Language == "bg").OrderBy(u => u.QuestionID).ToList(),
                Answers = new List<Answer>() 
            };
            var i = 0;
            foreach (var q in model.Questions)
            {
                Answer answer = new Answer();
                model.Answers.Add(new Answer()
                {
                    ID = i,
                    QuestionID = q.QuestionID,
                    UserName = CurrentUser.UserName
                });
                i++;
            }

            return View(model);
        }


        [HttpPost]
        public ActionResult Index([Bind] Evaluation model)
        {
            if (ModelState.IsValid)
            {
                _context.AddRange(model.Answers.Where(u=>u.UserName==CurrentUser.UserName));
                _context.SaveChanges();
                return RedirectToAction("ThankYou"); //PRG Pattern
            }
            //reload questions
            return View(Eval);
        }

        //private void CreateAnswers(Evaluation model)
        //{
        //    foreach (var q in model.Questions)
        //    {
        //        Answer selectedAnswer = new Answer();
        //        if (model.Answers[q.ID] != null)
        //        {
        //            selectedAnswer = model.Answers[q.ID];
        //        }

        //        _context.Answers.Add(new Answer()
        //        {
        //            QuestionID = q.ID,
        //            SelectedAnswer = selectedAnswer.SelectedAnswer,
        //            UserName = CurrentUser.UserName
        //        });
        //    }
        //    _context.SaveChanges();
        //}




    }
}
