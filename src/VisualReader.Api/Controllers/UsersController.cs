using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VisualReader
{
    [ApiController]
    [Route("vsr/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogoutAsync()
        {
            var command = new LogoutRequest();
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("verify/{id}")]
        public async Task<IActionResult> VerifyAsync([FromRoute] string id)
        {
            var command = new VerifyRequest(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("profile")]
        public async Task<IActionResult> UpdateProfileAsync([FromForm] UpdateProfileRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfileAsync(string id)
        {
            var command = new GetProfileRequest(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}