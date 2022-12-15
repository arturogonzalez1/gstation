using AutoMapper;
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
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Response<UserLoginTokenDto>>> Login([FromBody] UserLoginDto userLoginDto)
        {

            var userLoginTokenDto = await _authService.Login(userLoginDto.Email, userLoginDto.Password);

            var response = new Response<UserLoginTokenDto>();

            response.Data = userLoginTokenDto;

            return Ok(response);
        }

        [HttpPost("signup")]
        public async Task<ActionResult> Signup([FromBody] UserSignupDto userSignupDto)
        {
            var user = _mapper.Map<ApplicationUser>(userSignupDto);

            await _authService.Signup(user, userSignupDto.Password, userSignupDto.Role);

            return Ok();
        }

        // TODO: recovery password

    }
}
