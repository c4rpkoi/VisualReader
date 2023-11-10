using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VisualReader
{
    [ApiController]
    [Route("vsr/[controller]")]
    public class TacGiaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TacGiaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("search")]
        [Authorize]
        public async Task<IActionResult> SearchAsync([FromBody] GetAllTacGia command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        //[HttpGet("{id}")]
        //[Authorize]
        //public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        //{
        //    var command = new GetTacGiaById(id);
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAsync([FromBody] TacGiaRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutAsync([FromBody] EditTacGia command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync([FromBody] RemoveTacGia command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}