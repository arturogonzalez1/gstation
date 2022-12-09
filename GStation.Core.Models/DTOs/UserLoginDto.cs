using System.ComponentModel.DataAnnotations;

namespace GStation.Core.Models.DTOs
{
    public class UserLoginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
