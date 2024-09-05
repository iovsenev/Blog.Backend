using Blog.Application.Helpers;
using Blog.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers.Common;
[ApiController]
[Route("[controller]")]
public abstract class BaseController : ControllerBase
{
    protected new IActionResult Ok(object? result = null)
    {
        var envelope = ResponseFormat.Ok(result);

        return base.Ok(envelope);
    }

    protected IActionResult BadRequest(Error error)
    {
        var envelope = ResponseFormat.Error(error);

        return base.BadRequest(envelope);
    }
}
