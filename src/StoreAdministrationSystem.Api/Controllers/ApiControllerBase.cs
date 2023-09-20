using Microsoft.AspNetCore.Mvc;

namespace StoreAdministrationSystem.Api.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    [NonAction]
    protected IActionResult BadRequest(string message)
    {
        return new BadRequestObjectResult(base.ProblemDetailsFactory.CreateProblemDetails(base.HttpContext, 400, null, null, message, (string)base.Request.Path));
    }

    [NonAction]
    protected IActionResult Forbid(string code, string message)
    {
        ProblemDetails problemDetails = base.ProblemDetailsFactory.CreateProblemDetails(base.HttpContext, 403, null, null, message, (string)base.Request.Path);
        problemDetails.Extensions.Add("error", code);
        return new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }

    [NonAction]
    protected IActionResult NotFound(string message)
    {
        return new NotFoundObjectResult(base.ProblemDetailsFactory.CreateProblemDetails(base.HttpContext, 404, null, null, message, (string)base.Request.Path));
    }

    [NonAction]
    protected IActionResult NotFound(string code, string message)
    {
        ProblemDetails problemDetails = base.ProblemDetailsFactory.CreateProblemDetails(base.HttpContext, 404, null, null, message, (string)base.Request.Path);
        problemDetails.Extensions.Add("error", code);
        return new NotFoundObjectResult(problemDetails);
    }

    [NonAction]
    protected IActionResult Conflict(string message)
    {
        return new ConflictObjectResult(base.ProblemDetailsFactory.CreateProblemDetails(base.HttpContext, 409, null, null, message, (string)base.Request.Path));
    }

    [NonAction]
    protected IActionResult Conflict(string code, string message)
    {
        ProblemDetails problemDetails = base.ProblemDetailsFactory.CreateProblemDetails(base.HttpContext, 409, null, null, message, (string)base.Request.Path);
        problemDetails.Extensions.Add("error", code);
        return new ConflictObjectResult(problemDetails);
    }

    [NonAction]
    protected IActionResult PreconditionFailed(string message)
    {
        return base.Problem(message, statusCode: 412, instance: (string)base.Request.Path, title: "Precondition Failed");
    }

    [NonAction]
    protected IActionResult PreconditionFailed(string code, string message)
    {
        ProblemDetails problemDetails = base.ProblemDetailsFactory.CreateProblemDetails(base.HttpContext, 412, "Precondition Failed", null, message, (string)base.Request.Path);
        problemDetails.Extensions.Add("error", code);
        return new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }

    [NonAction]
    protected IActionResult UnprocessableEntity(string message)
    {
        return new UnprocessableEntityObjectResult(base.ProblemDetailsFactory.CreateProblemDetails(base.HttpContext, 422, null, null, message, (string)base.Request.Path));
    }

    [NonAction]
    protected IActionResult UnprocessableEntity(string code, string message)
    {
        ProblemDetails problemDetails = base.ProblemDetailsFactory.CreateProblemDetails(base.HttpContext, 422, null, null, message, (string)base.Request.Path);
        problemDetails.Extensions.Add("error", code);
        return new UnprocessableEntityObjectResult(problemDetails);
    }

    [NonAction]
    protected IActionResult InternalServerError(string error)
    {
        return base.Problem(error, statusCode: 500, instance: (string)base.Request.Path, title: "Internal Server Error");
    }

    [NonAction]
    protected IActionResult InternalServerError()
    {
        return base.Problem(null, statusCode: 500, instance: (string)base.Request.Path, title: "Internal Server Error");
    }
}
