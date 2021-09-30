using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Data;
using Hotel.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Hotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
           using (var scope = host.Services.CreateScope())
           {
               var services = scope.ServiceProvider;
               
               // Get our database context from the service provider
               var db = services.GetRequiredService<ApplicationDbContext>();
               
               // Get the UserManager and RoleManager also from the service provider
               var um = services.GetRequiredService<UserManager<ApplicationUser>>();
               var rm = services.GetRequiredService<RoleManager<IdentityRole>>();
               
               // Initialise the database using the initializer from Data/DbInitializer.cs
               DbInitializer.Initialize(db, um, rm);
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
