using GStation.Core.Models;
using GStation.Props.Constants;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace GStation.Persistence.EF.Seed
{
    public static class RoleSeed
    {
        public static void Seed(this RoleManager<ApplicationRole> roleManager)
        {

            var fields = typeof(Role).GetFields();

            foreach (FieldInfo field in fields)
            {

                var value = field.GetValue(null)!.ToString();

                if (!roleManager.RoleExistsAsync(value).Result)
                {
                    var role = new ApplicationRole();
                    role.Name = value;
                    var roleResult = roleManager.CreateAsync(role).Result;
                }
            }

        }
    }
}
