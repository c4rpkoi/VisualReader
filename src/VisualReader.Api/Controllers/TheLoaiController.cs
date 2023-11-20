using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VisualReader
{
    [ApiController]
    [Route("vsr/[controller]")]
    public class TheLoaiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TheLoaiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("search")]
        [Authorize]
        public async Task<IActionResult> SearchAsync([FromBody] GetAllTheLoai command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        //[HttpGet("{id}")]
        //[Authorize]
        //public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        //{
        //    var command = new GetTheLoaiById(id);
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAsync([FromBody] TheLoaiRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutAsync([FromBody] EditTheLoai command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync([FromBody] RemoveTheLoai command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}