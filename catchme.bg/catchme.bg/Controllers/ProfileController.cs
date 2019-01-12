using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Data;
using catchme.bg.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace catchme.bg.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class ProfileController : Controller
    {
        public catchmebgContext _bgcontext { get; set; }

        public CatchmeContext _context { get; set; }

        [BindProperty]
        protected ProfileViewModel ProfileViewModel { get; set; }

        public byte[] UserPhotoArray { get; set; }

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

        public ProfileController(catchmebgContext bgcontext, CatchmeContext context)
        {
            _bgcontext = bgcontext;
            _context = context;
        }


        public IActionResult Index()
        {
            var model = new ProfileViewModel();
            //https://docs.microsoft.com/en-gb/ef/core/querying/related-data
            //var currentProfile = (from u in _context.Profiles.Include(u=>u.ProfileUser) where (u.ProfileUser.Id == CurrentUser.Id) select u).FirstOrDefault();
            var currentProfile = (from u in _context.Profiles where (u.ProfileUser.Id == CurrentUser.Id) select u).FirstOrDefault();

            if (currentProfile != null)
            {
                model.ProfileUser = currentProfile.ProfileUser;
                model.Profile = currentProfile;
                model.Profile.ProfileUser = currentProfile.ProfileUser;
            }
            else
            {
                model.ProfileUser = CurrentUser;
                model.Profile = new Profile();
                model.Profile.ProfileUser = CurrentUser;
            }

            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind] ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentProfile = _context.Profiles.FirstOrDefault(u => u.ProfileUser.Id == CurrentUser.Id);

                var filePath = Path.GetTempFileName();
                // To convert the user uploaded Photo as Byte Array before save to DB

                if (Request.Form.Files.Count > 0)
                {
                    var poImgFile = Request.Form.Files["UserPhoto"];

                    if (poImgFile != null && poImgFile.Length > 0)
                    {
                        using (var inputStream = new FileStream(filePath, FileMode.Create))
                        {
                            // read file to stream
                            await poImgFile.CopyToAsync(inputStream);
                            // stream to byte array
                            UserPhotoArray = new byte[inputStream.Length];
                            inputStream.Seek(0, SeekOrigin.Begin);
                            inputStream.Read(UserPhotoArray, 0, UserPhotoArray.Length);
                            // get file name
                            string fName = poImgFile.FileName;
                        }
                    }

                }


                if (currentProfile != null)
                {
                    //_context.Profiles.Attach(model.Profile);
                    //_context.Entry(model.Profile).State = EntityState.Modified;
                    model.Profile = currentProfile;
                    model.Profile.DateLastChange = DateTime.Now;
                    model.Profile.ProfileUser = currentProfile.ProfileUser;
                    if (UserPhotoArray != null)
                    {
                        model.UserPhoto = UserPhotoArray;
                        model.ProfileUser.UserPhoto = UserPhotoArray;
                        CurrentUser.UserPhoto = UserPhotoArray;
                        _bgcontext.Update(CurrentUser);
                    }
                    _context.Profiles.Update(model.Profile);

                }
                else
                {
                    //_context.Profiles.Attach(model.Profile);
                    //_context.Entry(model.Profile).State = EntityState.Modified;
                    model.ProfileUser = CurrentUser;
                    model.ProfileUser.UserPhoto = UserPhotoArray;
                    CurrentUser.UserPhoto = UserPhotoArray;
                    model.Profile.ProfileUser = CurrentUser;
                    model.Profile.DateCreated = DateTime.Now;
                    model.Profile.DateLastChange = DateTime.Now;
                    model.UserPhoto = UserPhotoArray;
                    _bgcontext.Update(CurrentUser);
                    _context.Profiles.Add(model.Profile);

                }

                //_context.Profiles.Attach(model.Profile);
                //_context.Entry(model.Profile).State = EntityState.Modified;
                //_context.Profiles.Attach(model.Profile);
                _bgcontext.SaveChanges();
                _context.SaveChanges();
            }

            return View(model);
        }
    }
}