using System;
using catchme.bg.Areas.Identity.Data;
using catchme.bg.Data;
using catchme.bg.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

[assembly: HostingStartup(typeof(catchme.bg.Areas.Identity.IdentityHostingStartup))]
namespace catchme.bg.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //services.AddDbContext<catchmebgContext>(options =>
                //    options.UseSqlServer(
                //        context.Configuration.GetConnectionString("catchmebgContextConnection")));

                services.AddDbContextPool<catchmebgContext>(
                    options => options.UseMySql(context.Configuration.GetConnectionString("catchmebgContextConnection"), // replace with your Connection String
                        mySqlOptions =>
                        {
                            mySqlOptions.ServerVersion(new Version(5, 7, 24), ServerType.MySql); // replace with your Server Version and Type
                        }
                    ));

                services.AddDefaultIdentity<CatchmebgUser>()
                    .AddEntityFrameworkStores<catchmebgContext>();


            });
        }
    }
}