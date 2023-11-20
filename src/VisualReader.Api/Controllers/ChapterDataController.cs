using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VisualReader
{
    [ApiController]
    [Route("vsr/[controller]")]
    public class ChapterDataController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChapterDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("search")]
        [Authorize]
        public async Task<IActionResult> SearchAsync([FromBody] GetAllChapterData command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        //[HttpGet("{id}")]
        //[Authorize]
        //public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        //{
        //    var command = new GetChapterDataById(id);
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAsync([FromBody] ChapterDataRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutAsync([FromBody] EditChapterData command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync([FromBody] RemoveChapterData command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}