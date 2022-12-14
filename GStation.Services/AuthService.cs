using AutoMapper;
using GStation.Core.Models;
using GStation.Core.Models.DTOs;
using GStation.Core.Props;
using GStation.Core.Props.Constants;
using GStation.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GStation.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(IMapper mapper, UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task Signup(UserSignupDto userSignupDto)
        {

            var user = _mapper.Map<ApplicationUser>(userSignupDto);

            var result = await _userManager.CreateAsync(user, userSignupDto.Password);

            if (!result.Succeeded)
            {
                var errors = String.Join(" ", result.Errors.Select(error => error.Description));

                throw new CustomValidationException(errors);
            }

            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, userSignupDto.Role));
            await _userManager.AddToRoleAsync(user, userSignupDto.Role);

        }

        public async Task<Response<UserLoginTokenDto>> Login(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);

            if (user == null) throw new CustomValidationException(ErrorConstants.INVALID_CREDENTIALS);

            var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, true);

            if (!result.Succeeded)
            {
                throw new CustomValidationException(ErrorConstants.INVALID_CREDENTIALS);
            }

            var roles = await _userManager.GetRolesAsync(user);

            var userLoginTokenDto = GetUserLoginToken(user, roles);

            var response = new Response<UserLoginTokenDto>();

            response.Data = userLoginTokenDto;

            return response;

        }

        private UserLoginTokenDto GetUserLoginToken(ApplicationUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim("userId", user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            var expiration = DateTime.UtcNow.AddHours(1);

            var token = BuildToken(claims, expiration);

            return new UserLoginTokenDto(token, expiration);
        }

        private string BuildToken(List<Claim> claims, DateTime expiration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
