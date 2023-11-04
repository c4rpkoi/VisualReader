using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VisualReader
{
    [ApiController]
    [Route("vsr/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("search")]
        [Authorize]
        public async Task<IActionResult> SearchAsync([FromBody] GetCommentByParentId command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var command = new GetCommentById(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAsync([FromBody] CommentRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutAsync([FromBody] EditComment command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync([FromBody] RemoveComment command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}