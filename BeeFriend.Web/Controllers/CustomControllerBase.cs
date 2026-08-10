using BeeFriend.Core.Enums;
using BeeFriend.Core.Results;
using Microsoft.AspNetCore.Mvc;

namespace BeeFriend.Web.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
        protected ActionResult ReturnResponse<T>(
            Result<T> result, 
            Func<T, ActionResult> successResponse)
        {
            if (result.IsFailure)
                return HandleFailure(result);

            return successResponse(result.Value!);
        }

        private ActionResult HandleFailure(Result result)
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
