using Microsoft.AspNetCore.Mvc;
using VisualReader.Application.Models.Bases;
using VisualReader.Application.Services.Abstractions;

namespace VisualReader.Api.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;

        public AuthController(IAuthenticationService authenticationService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody] TokenRequest request)
        {
            var user = await _userService.GetUserByEmailAsync(request.UserName);
            if (user == null)
                return BadRequest();

            var userValid = _userService.CheckLoginSuccess(user.Password, request.Password);
            if (!userValid)
                return BadRequest();

            var tokenResponse = _authenticationService.GenerateToken(user.Email, user.Role);
            return Ok(tokenResponse);
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> RevokeToken([FromBody] string token)
        {
            var tokenResponse = await _authenticationService.RevokeTokenAsync(token);
            return Ok(tokenResponse);
        }
    }
}