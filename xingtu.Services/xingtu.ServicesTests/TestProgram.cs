using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace xingtu.ServicesTests
{
    public class TestProgram
    {
        static int port = 7001;

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
     WebHost.CreateDefaultBuilder(args)
         .UseUrls($"http://*:{port}")
         .ConfigureAppConfiguration((hostingContext, config) =>
         {
             config.Sources.Clear();

             var env = hostingContext.HostingEnvironment;

             config.AddJsonFile("appsettings.json",
                    optional: true,
                    reloadOnChange: true);

             config.AddEnvironmentVariables();

             if (args != null)
             {
                 config.AddCommandLine(args);
             }
         })
         .UseStartup<Startup>();
    }
}
