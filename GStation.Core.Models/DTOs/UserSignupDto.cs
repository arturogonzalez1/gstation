using System.ComponentModel.DataAnnotations;

namespace GStation.Core.Models.DTOs
{
    public class UserSignupDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public PersonSignupDto Person { get; set; }
    }
}
