using Blog.Api.Controllers.Common;
using Blog.Application.Mediators;
using Blog.Application.Services.Admin.PublishArticle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
[Authorize(Roles ="ADMIN,MODERATOR")]
public class AdminController : BaseController
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("publishArticle")]
    public async Task<IActionResult> PublishArticle([FromBody] PostArticleAdminCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command);

        if (result.IsFailure)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }

    [HttpGet("UnPostedArticle")]
    public async Task<IActionResult> GetUnPostedArticles(CancellationToken cancellationToken)
    {
        return Ok();
    }
}
