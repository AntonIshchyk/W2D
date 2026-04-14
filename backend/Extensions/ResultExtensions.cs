using Backend.Contracts.Common;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Extensions;

public static class ResultExtensions
{
    public static ActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
    {
        return result.Status switch
        {
            ResultStatus.Success => controller.Ok(result.Value),
            ResultStatus.NotFound => controller.NotFound(new { message = result.Error }),
            ResultStatus.Unauthorized => controller.StatusCode(StatusCodes.Status403Forbidden, new { message = result.Error }),
            ResultStatus.Invalid => controller.BadRequest(new { message = result.Error }),
            _ => throw new InvalidOperationException("Unhandled result status")
        };
    }
}
