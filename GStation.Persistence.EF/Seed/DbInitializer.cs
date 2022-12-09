using GStation.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

                    context.Database.Migrate();

                    roleManager.Seed();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

        }
    }
}
