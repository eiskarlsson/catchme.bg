using catchme.bg.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace catchme.bg.Controllers
{
    internal class UserManager
    {
        private UserStore<CatchmebgUser> store;

        public UserManager(UserStore<CatchmebgUser> store)
        {
            this.store = store;
        }
    }
}