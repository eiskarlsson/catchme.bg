using System.IO;
using System.Linq;
using System.Security.Claims;
using catchme.bg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace catchme.bg.Areas.Main.Controllers
{
    [Area("Main")]
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public catchmebgContext _context { get; set; }

        public HomeController(catchmebgContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public FileContentResult UserPhotos()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                // to get the user details to load user Image
                var user = _context.Users.FirstOrDefault(x => x.Id == userId);

                if (userId == null || user?.UserPhoto == null)
                {
                    var separator = Path.DirectorySeparatorChar;
                    var path = $"wwwroot{separator}images{separator}noImg.png";
                    string fileName = Path.Combine(_environment.ContentRootPath, path);

                    byte[] imageData = null;
                    FileInfo fileInfo = new FileInfo(fileName);
                    long imageFileLength = fileInfo.Length;
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageData = br.ReadBytes((int)imageFileLength);
                    return File(imageData, "image/png");

                }
                else
                {
                    return new FileContentResult(user.UserPhoto, "image/jpeg");
                }
               
            }
            else
            {
                var separator = Path.DirectorySeparatorChar;
                var path = $"wwwroot{separator}images{separator}noImg.png";
                string fileName = Path.Combine(_environment.ContentRootPath, path);

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);
                return File(imageData, "image/png");

            }
        }


    }
}
