﻿using System;
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

namespace catchme.bg.Controllers
{
    /// <summary>
    /// Based on the SO Question: https://stackoverflow.com/questions/39062061/post-list-of-list-of-model-object-to-controller-in-asp-net-mvc
    /// </summary>
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
            
            foreach (var q in model.Questions)
            {
                model.Answers.Add(new Answer()
                {
                    QuestionID = q.QuestionID,
                    UserName = CurrentUser.UserName
                });
            }

            return View(model);
        }


        [HttpPost]
        public ActionResult Index([Bind] Evaluation model)
        {
            if (ModelState.IsValid)
            {
                var answers = _context.Answers.Where(u => u.UserName == CurrentUser.UserName);
                if (answers.Any())
                {
                    foreach (var answer in model.Answers)
                    {
                        _context.Answers.Update(answer);
                    }
                }
                else
                {
                    _context.AddRange(model.Answers.Where(u=>u.UserName==CurrentUser.UserName));
                }
                _context.SaveChanges();
                return RedirectToAction("ThankYou"); //PRG Pattern
            }
            //reload questions
            return View(Eval);
        }

        public ActionResult ThankYou()
        {
            return View();
        }




    }
}
