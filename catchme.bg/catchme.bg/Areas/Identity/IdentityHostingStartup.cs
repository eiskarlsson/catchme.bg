using System;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(catchme.bg.Areas.Identity.IdentityHostingStartup))]
namespace catchme.bg.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<catchmebgContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("catchmebgContextConnection")));

                services.AddDefaultIdentity<CatchmebgUser>()
                    .AddEntityFrameworkStores<catchmebgContext>();
            });
        }
    }
}