﻿using Blog.Api.Controllers.Common;
using Blog.Application.Mediators;
using Blog.Application.Services.Users.Commands.CreateArticle;
using Blog.Application.Services.Users.Commands.CreateComment;
using Blog.Application.Services.Users.Queries.GetById;
using Blog.Application.Services.Users.Queries.GetByPage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
/// <summary>
/// 
/// </summary>
public class UserController : BaseController
{
    private readonly IMediator _mediator;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public UserController(
        IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получение общего списка пользователь имеющих опубликованные статьи. 
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
    
    /// <summary>
    /// Создание статьи через пользователя 
    /// </summary>
    /// <param name="command"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles ="ADMIN,USER,MODERATOR")]
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
    /// <summary>
    /// Получение статьи по Id
    /// </summary>
    /// <param name="id">Уникальный идентификатор статьи</param>
    /// <param name="canctlationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken canctlationToken)
    {
        var query = new GetByIdQuery(id);

        var result = await _mediator.Send<GetByIdResponse>(query, canctlationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }

    /// <summary>
    /// Создание комментария пользователя.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize]
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

