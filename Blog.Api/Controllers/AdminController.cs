using Blog.Api.Controllers.Common;
using Blog.Application.Mediators;
using Blog.Application.Services.Admin.PublishArticle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
[Authorize(Roles = "ADMIN")]
public class AdminController : BaseController
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetUnPostedArticles(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetRoles(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeArticleStatus([FromBody] PostArticleAdminCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command);

        if (result.IsFailure)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateRole()
    {
        return Ok();
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeUserStatus()
    {
        return Ok();
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteRole()
    {
        return Ok();
    }
}
