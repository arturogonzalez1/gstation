using System.ComponentModel.DataAnnotations;

namespace GStation.Core.Models.DTOs
{
    public class UserSignupDto
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
