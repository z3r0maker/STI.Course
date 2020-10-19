using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using STI.API;
using STI.Data;

namespace STI.Course
{
    public class Program
    {
        public static void Main(string[] args)
        {


            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var log = services.GetService<ILogger<Program>>();
                var db = services.GetService<STIContext>();
                try
                {
                    log.LogInformation("Project started to review migration files");
                    db.Database.Migrate();
                    log.LogInformation("Project executed migrations succesfully");
                }
                catch (Exception ex)
                {
                    log.LogError(ex.Message);
                    throw;
                }
            }
            host.Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
