using BeeFriend.Core.Results;
using BeeFriend.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
        protected ActionResult HandleFailure(Result result)
        {
            if (result.Error == null)
                return StatusCode(500, "An unknown error occurred.");

            return result.Error.Type switch
            {
                ErrorType.Validation => BadRequest(result.Error),
                ErrorType.NotFound => NotFound(result.Error),
                ErrorType.Unauthorized => Unauthorized(result.Error),
                _ => throw new InvalidOperationException(
                    $"Unsupported error type '{result.Error.Type}'.")
            };
        }
    }
}
