using GStation.Core.Models;
using GStation.Core.Models.DTOs;

namespace GStation.Services.Interfaces
{
    public interface IAuthService
    {
        Task Signup(UserSignupDto userSignupDto);
    }
}
