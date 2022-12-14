using GStation.Core.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace GStation.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public StatusEnum Status { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
