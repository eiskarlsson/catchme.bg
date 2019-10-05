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

namespace catchme.bg.Controllers
{
    /// <summary>
    /// Based on the SO Question: https://stackoverflow.com/questions/39062061/post-list-of-list-of-model-object-to-controller-in-asp-net-mvc
    /// </summary>
    [Authorize]
    [Area("Main")]
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
            set => _currentUser = value;
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
            ViewBag.Current = "Mbti";

            var answers = _context.Answers.Where(u => u.UserName == CurrentUser.UserName);
            if (answers.Any())
            {
                ViewBag.mbti_type = GetResult();
                return View();
            }
            else
            {
                return RedirectToAction("Step1"); //PRG Pattern
            }
        }

        [HttpGet]
        public IActionResult Step1()
        {
            ViewBag.Current = "Mbti";

            var answersToDelete = _context.Answers.Where(u => u.UserName == CurrentUser.UserName);
            _context.Answers.RemoveRange(answersToDelete);
            _context.SaveChanges();

            var model = new Evaluation()
                {
                    UserName = CurrentUser.UserName,
                    Questions = _context.Questions.Where(u => u.Language == "en").Where(u => u.QuestionID >= 1 && u.QuestionID <= 25).OrderBy(u => u.QuestionID).ToList(),
                    Answers = new List<Answer>()
                };

            foreach (var q in model.Questions.Where(u => u.Language == "en").Where(u => u.QuestionID >= 1 && u.QuestionID <= 25))
            {
                model.Answers.Add(new Answer()
                {
                    QuestionID = q.QuestionID,
                    UserName = CurrentUser.UserName
                });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Step2()
        {
            ViewBag.Current = "Mbti";

            var model = new Evaluation()
            {
                UserName = CurrentUser.UserName,
                Questions = _context.Questions.Where(u => u.Language == "en").Where(u => u.QuestionID >= 26 && u.QuestionID <= 50).OrderBy(u => u.QuestionID).ToList(),
                Answers = new List<Answer>()
            };

            foreach (var q in model.Questions.Where(u => u.Language == "en").Where(u => u.QuestionID >= 26 && u.QuestionID <= 50).OrderBy(u => u.QuestionID))
            {
                model.Answers.Add(new Answer()
                {
                    QuestionID = q.QuestionID,
                    UserName = CurrentUser.UserName
                });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Step3()
        {
            ViewBag.Current = "Mbti";

            var model = new Evaluation()
            {
                UserName = CurrentUser.UserName,
                Questions = _context.Questions.Where(u => u.Language == "en").Where(u => u.QuestionID >= 51 && u.QuestionID <= 70).OrderBy(u => u.QuestionID).ToList(),
                Answers = new List<Answer>()
            };

            foreach (var q in model.Questions.Where(u => u.Language == "en").Where(u => u.QuestionID >= 51 && u.QuestionID <= 70).OrderBy(u => u.QuestionID))
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
        [ValidateAntiForgeryToken]
        public ActionResult Step1([Bind] Evaluation model)
        {
            ViewBag.Current = "Mbti";

            if (ModelState.IsValid)
            {
                var answers = _context.Answers.Where(u => u.UserName == CurrentUser.UserName).Where(u => u.QuestionID >= 1 && u.QuestionID <= 25);
                if (answers.Any())
                {
                    foreach (var answer in model.Answers.Where(u => u.QuestionID >= 1 && u.QuestionID <= 25))
                    {
                        _context.Answers.Update(answer);
                    }
                }
                else
                {
                    _context.AddRange(model.Answers.Where(u => u.UserName == CurrentUser.UserName).Where(u => u.QuestionID >= 1 && u.QuestionID <= 25));
                }
                _context.SaveChanges();
                return RedirectToAction("Step2"); //PRG Pattern
            }
            else
            {
                //reload questions
                model.UserName = CurrentUser.UserName;
                model.Questions = _context.Questions.Where(u => u.Language == "en")
                    .Where(u => u.QuestionID >= 1 && u.QuestionID <= 25).OrderBy(u => u.QuestionID).ToList();
                return View(model);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Step2([Bind] Evaluation model)
        {
            ViewBag.Current = "Mbti";

            if (ModelState.IsValid)
            {
                var answers = _context.Answers.Where(u => u.UserName == CurrentUser.UserName).Where(u => u.QuestionID >= 26 && u.QuestionID <= 50);
                if (answers.Any())
                {
                    foreach (var answer in model.Answers.Where(u => u.QuestionID >= 26 && u.QuestionID <= 50))
                    {
                        _context.Answers.Update(answer);
                    }
                }
                else
                {
                    _context.AddRange(model.Answers.Where(u => u.UserName == CurrentUser.UserName).Where(u => u.QuestionID >= 26 && u.QuestionID <= 50));
                }
                _context.SaveChanges();
                return RedirectToAction("Step3"); //PRG Pattern
            }
            else
            {
                //reload questions
                model.UserName = CurrentUser.UserName;
                model.Questions = _context.Questions.Where(u => u.Language == "en")
                    .Where(u => u.QuestionID >= 26 && u.QuestionID <= 50).OrderBy(u => u.QuestionID).ToList();
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Step3([Bind] Evaluation model)
        {
            ViewBag.Current = "Mbti";

            if (ModelState.IsValid)
            {
                var answers = _context.Answers.Where(u => u.UserName == CurrentUser.UserName).Where(u => u.QuestionID >= 51 && u.QuestionID <= 70);
                if (answers.Any())
                {
                    foreach (var answer in model.Answers.Where(u => u.QuestionID >= 51 && u.QuestionID <= 70))
                    {
                        _context.Answers.Update(answer);
                    }
                }
                else
                {
                    _context.AddRange(model.Answers.Where(u => u.UserName == CurrentUser.UserName).Where(u => u.QuestionID >= 51 && u.QuestionID <= 70));
                }
                _context.SaveChanges();
                return RedirectToAction("ThankYou"); //PRG Pattern
            }
            else
            {
                //reload questions
                model.UserName = CurrentUser.UserName;
                model.Questions = _context.Questions.Where(u => u.Language == "en")
                    .Where(u => u.QuestionID >= 51 && u.QuestionID <= 70).OrderBy(u => u.QuestionID).ToList();
                return View(model);
            }
        }

        public ActionResult ThankYou()
        {
            ViewBag.Current = "Mbti";
            ViewBag.mbti_type = GetResult();
            CurrentUser.Mbti = ViewBag.mbti_type;
            _bgcontext.Users.Update(CurrentUser);
            _bgcontext.SaveChanges();
            return View();
        }

        private string GetResult()
        {
            var mbti_type = String.Empty;
            var results = new List<Answer>();
            results.Insert(0, null);//Questions start at index 1
            results.AddRange(_context.Answers.Where(u => u.UserName == CurrentUser.UserName));


            int col1A = 0;
            int col1B = 0;
            if (results[1] != null && results[8] != null && results[15] != null && results[22] != null && results[29] != null &&
                results[36] != null && results[43] != null && results[50] != null && results[57] != null && results[64] != null)
            {
                col1A = CountTrue(results[1].SelectedAnswer == 1, results[8].SelectedAnswer == 1, results[15].SelectedAnswer == 1, results[22].SelectedAnswer == 1,
                    results[29].SelectedAnswer == 1, results[36].SelectedAnswer == 1, results[43].SelectedAnswer == 1, results[50].SelectedAnswer == 1, results[57].SelectedAnswer == 1,
                    results[64].SelectedAnswer == 1);
                col1B = 10 - col1A;
            }

            int col2A = 0;
            int col2B = 0;
            if (results[2] != null && results[9] != null && results[16] != null && results[23] != null && results[30] != null &&
                results[37] != null && results[44] != null && results[51] != null && results[58] != null && results[65] != null)
            {
                col2A = CountTrue(results[2].SelectedAnswer == 1, results[9].SelectedAnswer == 1, results[16].SelectedAnswer == 1, results[23].SelectedAnswer == 1,
                    results[30].SelectedAnswer == 1, results[37].SelectedAnswer == 1, results[44].SelectedAnswer == 1, results[51].SelectedAnswer == 1, results[58].SelectedAnswer == 1,
                    results[65].SelectedAnswer == 1);
                col2B = 10 - col1A;
            }

            int col3A = 0;
            int col3B = 0;
            if (results[3] != null && results[10] != null && results[17] != null && results[24] != null && results[31] != null &&
                results[38] != null && results[45] != null && results[52] != null && results[59] != null && results[66] != null)
            {
                col3A = CountTrue(results[3].SelectedAnswer == 1, results[10].SelectedAnswer == 1, results[17].SelectedAnswer == 1, results[24].SelectedAnswer == 1,
                    results[31].SelectedAnswer == 1, results[38].SelectedAnswer == 1, results[45].SelectedAnswer == 1, results[52].SelectedAnswer == 1, results[59].SelectedAnswer == 1,
                    results[66].SelectedAnswer == 1);
                col3B = 10 - col3A;
            }

            int col4A = 0;
            int col4B = 0;
            if (results[4] != null && results[11] != null && results[18] != null && results[25] != null && results[32] != null &&
                results[39] != null && results[46] != null && results[53] != null && results[60] != null && results[67] != null)
            {
                col4A = CountTrue(results[4].SelectedAnswer == 1, results[11].SelectedAnswer == 1, results[18].SelectedAnswer == 1, results[25].SelectedAnswer == 1,
                    results[32].SelectedAnswer == 1, results[39].SelectedAnswer == 1, results[46].SelectedAnswer == 1, results[53].SelectedAnswer == 1, results[60].SelectedAnswer == 1,
                    results[67].SelectedAnswer == 1);
                col4B = 10 - col4A;
            }

            int col5A = 0;
            int col5B = 0;
            if (results[5] != null && results[12] != null && results[19] != null && results[26] != null && results[33] != null &&
                results[40] != null && results[47] != null && results[54] != null && results[61] != null && results[68] != null)
            {
                col5A = CountTrue(results[5].SelectedAnswer == 1, results[12].SelectedAnswer == 1, results[19].SelectedAnswer == 1, results[26].SelectedAnswer == 1,
                    results[33].SelectedAnswer == 1, results[40].SelectedAnswer == 1, results[47].SelectedAnswer == 1, results[54].SelectedAnswer == 1, results[61].SelectedAnswer == 1,
                    results[68].SelectedAnswer == 1);
                col5B = 10 - col5A;
            }

            int col6A = 0;
            int col6B = 0;
            if (results[6] != null && results[13] != null && results[20] != null && results[27] != null && results[34] != null &&
                results[41] != null && results[48] != null && results[55] != null && results[62] != null && results[69] != null)
            {
                col6A = CountTrue(results[6].SelectedAnswer == 1, results[13].SelectedAnswer == 1, results[20].SelectedAnswer == 1, results[27].SelectedAnswer == 1,
                    results[34].SelectedAnswer == 1, results[41].SelectedAnswer == 1, results[48].SelectedAnswer == 1, results[55].SelectedAnswer == 1, results[62].SelectedAnswer == 1,
                    results[69].SelectedAnswer == 1);
                col6B = 10 - col6A;
            }

            int col7A = 0;
            int col7B = 0;
            if (results[7] != null && results[14] != null && results[21] != null && results[28] != null && results[35] != null &&
                results[42] != null && results[49] != null && results[56] != null && results[63] != null && results[70] != null)
            {
                col7A = CountTrue(results[7].SelectedAnswer == 1, results[14].SelectedAnswer == 1, results[21].SelectedAnswer == 1, results[28].SelectedAnswer == 1,
                    results[35].SelectedAnswer == 1, results[42].SelectedAnswer == 1, results[49].SelectedAnswer == 1, results[56].SelectedAnswer == 1, results[63].SelectedAnswer == 1,
                    results[70].SelectedAnswer == 1);
                col7B = 10 - col7A;
            }

            mbti_type = col1A >= col1B ? "E" : "I";


            if (col2A + col3A >= col2B + col3B)
            {
                mbti_type += "S";
            }
            else
            {
                mbti_type += "N";
            }


            if (col4A + col5A >= col4B + col5B)
            {
                mbti_type += "T";
            }
            else
            {
                mbti_type += "F";
            }

            if (col6A + col7A >= col6B + col7B)
            {
                mbti_type += "J";
            }
            else
            {
                mbti_type += "P";
            }

            return mbti_type;
        }

        public static int CountTrue(params bool[] args)
        {
            return args.Count(t => t);
        }


    }
}
