using GStation.Core.Models;
using GStation.Core.Models.DTOs;
using GStation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GStation.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response<UserLoginTokenDto>>> Login([FromBody] UserLoginDto userLoginDto)
        {
            var response = await _authService.Login(userLoginDto);

            return Ok(response);
        }

        [HttpPost("signup")]
        public async Task<ActionResult> Signup([FromBody] UserSignupDto userSignInDto)
        {
            await _authService.Signup(userSignInDto);

            return Ok();
        }

        // TODO: recovery password

    }
}
