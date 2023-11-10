using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VisualReader
{
    [ApiController]
    [Route("vsr/[controller]")]
    public class TruyenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TruyenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("search")]
        [Authorize]
        public async Task<IActionResult> SearchAsync([FromBody] GetAllTruyen command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        //[HttpGet("{id}")]
        //[Authorize]
        //public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        //{
        //    var command = new GetTruyenById(id);
        //    var response = await _mediator.Send(command);
        //    return Ok(response);
        //}

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAsync([FromBody] TruyenRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> PutAsync([FromBody] EditTruyen command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync([FromBody] RemoveTruyen command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}