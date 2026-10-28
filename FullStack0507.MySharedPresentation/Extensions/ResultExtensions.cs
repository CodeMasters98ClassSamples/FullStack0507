using FullStack0507.MyWebApi.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace FullStack0507.MySharedPresentation.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult(this Result result)
    {
        if (result.IsSuccess)
            return new OkObjectResult(result);

        return new ObjectResult(result)
        {
            StatusCode = (int)result.Status,
        };
    }

    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            return new OkObjectResult(result);

        return new ObjectResult(result)
        {
            StatusCode = (int)result.Status,
        };
    }

    public static IActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
    {
        if (result.IsSuccess)
            return new OkObjectResult(result);

        var problemDetails = new ProblemDetails
        {
            Type = $"https://httpstatuses.com/{(int)result.Status}",
            Title = result.Error.Code,
            Detail = result.Error.Message,
            Status = (int)result.Status,
            Instance = controller.HttpContext.Request.Path
        };

        return controller.StatusCode((int)result.Status, problemDetails);

    }
}

