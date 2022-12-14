using GStation.Core.Models;
using GStation.Persistence.EF.Seed.Fixtures;
using GStation.Props.Constants;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GStation.Persistence.EF.Seed
{
    public static class UserSeed
    {
        public static void Seed(this UserManager<ApplicationUser> userManager, bool isDevelop)
        {

            if (userManager.FindByEmailAsync("superadmin@gstation.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "superadmin@gstation.com";
                user.Email = "superadmin@gstation.com";
                user.Person = PersonFixture.GetPerson();
                user.Person.Name = "Super Admin";

                var result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, Role.SUPERADMIN)).Wait();
                    userManager.AddToRoleAsync(user, Role.SUPERADMIN).Wait();
                }
            }

            if (!isDevelop)
            {
                return;
            }

            if (userManager.FindByEmailAsync("admin@gstation.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@gstation.com";
                user.Email = "admin@gstation.com";
                user.Person = PersonFixture.GetPerson();
                user.Person.Name = "Admin";

                var result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, Role.ADMIN)).Wait();
                    userManager.AddToRoleAsync(user, Role.ADMIN).Wait();
                }
            }

            if (userManager.FindByEmailAsync("customer@gstation.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "customer@gstation.com";
                user.Email = "customer@gstation.com";
                user.Person = PersonFixture.GetPerson();
                user.Person.Name = "Customer";

                var result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, Role.CUSTOMER)).Wait();
                    userManager.AddToRoleAsync(user, Role.CUSTOMER).Wait();
                }
            }

        }
    }
}
