using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Data;
using catchme.bg.Models;
using Microsoft.AspNetCore.Mvc;
/// <summary>
/// Based on the SO Question: https://stackoverflow.com/questions/12844763/getting-a-list-of-radio-button-values-in-asp-mvc-3/12845534#12845534
/// </summary>

namespace catchme.bg.Controllers
{
    public class MbtiController : Controller
    {
        public catchmebgContext _bgcontext { get; set; }

        public CatchmeContext _context { get; set; }

        protected Evaluation Eval { get; set; }

        protected CatchmebgUser CurrentUser { get; set; }

        protected string userId;

        public MbtiController(catchmebgContext bgcontext, CatchmeContext context)
        {
            _bgcontext = bgcontext;
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


            }
            
            if (userId != null)
            {
                CurrentUser = _bgcontext.Users.FirstOrDefault(x => x.Id == userId);
            }

            Eval = new Evaluation()
            {
                UserName = CurrentUser.UserName,
                Questions = _context.Questions.ToList(),
                Answers = _context.Answers.Where(u=>u.UserName==CurrentUser.UserName).ToList()
            };
            return View(Eval);
        }


            





            
    }
}
