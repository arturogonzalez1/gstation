using AutoMapper;
using GStation.Core.Models;
using GStation.Core.Models.DTOs;
using GStation.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GStation.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Signup(UserSignupDto userSignupDto)
        {

            var user = _mapper.Map<ApplicationUser>(userSignupDto);

            await _userManager.CreateAsync(user, userSignupDto.Password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, userSignupDto.Role));
            await _userManager.AddToRoleAsync(user, userSignupDto.Role);

        }
    }
}
