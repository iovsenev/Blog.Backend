using Blog.Api.Controllers.Common;
using Blog.Application.Mediators;
using Blog.Application.Services.Users.Commands.CreateArticle;
using Blog.Application.Services.Users.Commands.CreateComment;
using Blog.Application.Services.Users.Commands.CreateUser;
using Blog.Application.Services.Users.Queries.GetById;
using Blog.Application.Services.Users.Queries.GetByPage;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
public class UserController : BaseController
{
    private readonly IMediator _mediator;

    public UserController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Возвращает список пользователей по страницам и общее количество пользователей в базе. 
    /// </summary>
    /// <param name="query">GetUserByPageQuery</param>
    /// <param name="token">CancelationToken</param>
    /// <returns>GetAllUsersByPageResponse</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery]
        GetUsersByPageQuery query,
        CancellationToken token)
    {
        var entities = await _mediator.Send<GetAllUsersByPageResponse>(query, token);

        if(entities.IsFailure)
            return BadRequest(entities.Error);

        return Ok(entities.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserCommand command,
        CancellationToken token)
    {
        var result = await _mediator.Send(command, token);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> PostArticle(
        [FromBody]
        CreateArticleCommand command,
        CancellationToken token)
    {
        var result = await _mediator.Send(command , token);
        if (result.IsFailure)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken token)
    {
        var query = new GetByIdQuery(id);

        var result = await _mediator.Send<GetByIdResponse>(query, token);

        if (result.IsFailure)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> PostComment(
        [FromBody]
        CreateCommentCommand command,
        CancellationToken token)
    {
        var result = await _mediator.Send(command, token);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}

