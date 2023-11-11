using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VisualReader.Api.Controllers
{
    [ApiController]
    [Route("vsr/[controller]")]

    public class FavoriteListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoriteListController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostAsync([FromBody] FavoriteListRequest command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost("delete")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync([FromBody] RemoveFavoriteList command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
