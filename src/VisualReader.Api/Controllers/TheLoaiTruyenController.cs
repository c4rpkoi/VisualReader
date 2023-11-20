using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VisualReader
{
    [ApiController]
    [Route("vsr/[controller]")]
    public class TheLoaiTruyenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TheLoaiTruyenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("search")]
        [Authorize]
        public async Task<IActionResult> SearchAsync([FromBody] GetAllTheLoaiTruyen command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        //[HttpGet("{id}")]
        //[Authorize]
        //public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        //{
        //    var command = new GetTheLoaiTruyenById(id);
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAsync([FromBody] TheLoaiTruyenRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutAsync([FromBody] EditTheLoaiTruyen command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync([FromBody] RemoveTheLoaiTruyen command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}