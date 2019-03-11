using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace catchme.bg.Areas.Identity.Data
{
    public class CatchmebgUser : IdentityUser
    {
        // Here we add a byte to Save the user Profile Picture
        [PersonalData]
        public byte[] UserPhoto { get; set; }

        [PersonalData]
        public string Mbti { get; set; }
    }
}
