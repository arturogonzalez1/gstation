using GStation.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace GStation.Persistence.EF.Seed
{
    public static class DbInitializer
    {
        public static void InitializeDatabase(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var service = scope.ServiceProvider;

                try
                {
                    var context = service.GetRequiredService<ApplicationDbContext>();
                    var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = service.GetRequiredService<RoleManager<ApplicationRole>>();
                    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                    var isDevelop = environment == Environments.Development;

                    context.Database.Migrate();

                    roleManager.Seed();
                    userManager.Seed(isDevelop);
                    context.SeedUbication();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }
    }
}
