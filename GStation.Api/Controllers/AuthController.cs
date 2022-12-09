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
        public void Login([FromBody] string value)
        {

        }

        [HttpPost("signup")]
        public async Task<ActionResult<Response<bool>>> Signup([FromBody] UserSignupDto userSignInDto)
        {
            try
            {
                await _authService.Signup(userSignInDto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
