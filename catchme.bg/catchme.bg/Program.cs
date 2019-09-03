using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace catchme.bg
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSetting("detailedErrors", "true")
                .UseKestrel(options => {
                    options.Listen(IPAddress.Loopback, 5000); //HTTP port
                })
                .UseStartup<Startup>()
                .CaptureStartupErrors(true);
    }
}