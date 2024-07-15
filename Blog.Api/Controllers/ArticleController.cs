using Blog.Api.Controllers.Common;
using Blog.Application.Mediators;
using Blog.Application.Services.Articles.Queries.GetAll;
using Blog.Application.Services.Articles.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
/// <summary>
/// Контроллер работы со статьями.
/// </summary>
public class ArticleController : BaseController
{
    private readonly IMediator _mediator;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public ArticleController(IMediator mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// Получения списка статей по страницам и общего числа статей.
    /// </summary>
    /// <param name="query">Запрос по страницам по умолчанию имеет значения pageIndex = 1 pageSize = 10</param>
    /// <param name="cancellationToken">Cancelation token</param>
    /// <returns>Список ArticleShortViewModel</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery]
        GetArticlesByPageQuery query,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send<GetArticlesByPageResponse>(query, cancellationToken);

        if (response.IsFailure)
            return BadRequest(response.Error);

        return Ok(response.Value);
    }
    /// <summary>
    /// Получения одной статьи по уникальному идентификатору статьи
    /// </summary>
    /// <param name="id">Уникальный Id пользователя</param>
    /// <param name="cancelationToken">Cancellation Token</param>
    /// <returns>ArticleFullViewModel</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id, 
        CancellationToken cancelationToken)
    {
        var query = new GetArticleByIdQuery(id);
        var result = await _mediator.Send<GetArticleByIdResponse>(query, cancelationToken);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}
