using GStation.Core.Models;
using GStation.Core.Models.DTOs;

namespace GStation.Services.Interfaces
{
    public interface IAuthService
    {
        Task Signup(ApplicationUser user, string password, string role);
        Task<UserLoginTokenDto> Login(string email, string password);
    }
}
