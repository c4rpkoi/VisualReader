using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VisualReader.Api.Controllers
{
    [ApiController]
    [Route("vsr/[controller]")]

    public class BlockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlockController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAsync([FromBody] BlockRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync([FromBody] RemoveBlock command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
