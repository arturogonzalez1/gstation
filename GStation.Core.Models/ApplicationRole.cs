using Microsoft.AspNetCore.Identity;

namespace GStation.Core.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
