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
        private readonly IPersonService _personService;

        public AuthService(IMapper mapper, UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration,
            IPersonService personService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _personService = personService;
        }

        public async Task Signup(ApplicationUser user, string password, string role)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = String.Join(" ", result.Errors.Select(error => error.Description));

                throw new CustomValidationException(errors);
            }

            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, role));
            await _userManager.AddToRoleAsync(user, role);

        }

        public async Task<UserLoginTokenDto> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) throw new CustomValidationException(ErrorConstants.INVALID_CREDENTIALS);

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, true);

            if (!result.Succeeded)
            {
                throw new CustomValidationException(ErrorConstants.INVALID_CREDENTIALS);
            }

            var roles = await _userManager.GetRolesAsync(user);

            user.Person = await _personService.GetPersonById(user.PersonId);

            var userLoginTokenDto = GetUserLoginToken(user, roles.FirstOrDefault());

            return userLoginTokenDto;

        }

        private UserLoginTokenDto GetUserLoginToken(ApplicationUser user, string role)
        {
            var claims = new List<Claim>
            {
                new Claim("userId", user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.Add(new Claim(ClaimTypes.Role, role));

            var expiration = DateTime.UtcNow.AddHours(1);

            var token = BuildToken(claims, expiration);

            return new UserLoginTokenDto()
            {
                UserId = user.Id,
                Email = user.Email,
                CompleteName = user.Person.GetCompleteName(),
                Role = role,
                Token = token,
                Expiration = expiration,
            };
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
