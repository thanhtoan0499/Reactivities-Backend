using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            bool hasValue = false;
            if (result == null) return NotFound();
            if (result.IsSuccess)
            {
                if (result.Value != null)
                {
                    hasValue = true;
                }
            }
            if (hasValue)
            {
                return Ok(result.Value);
            }
            if (!hasValue)
            {
                return NotFound();
            }
            return BadRequest(result.Error);
        }
    }
}
