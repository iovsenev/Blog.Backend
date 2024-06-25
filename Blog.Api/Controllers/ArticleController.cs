using Blog.Api.Controllers.Common;
using Blog.Application.Interfaces.Services;
using Blog.Application.Mediators;
using Blog.Application.Services.Articles.Queries.GetAll;
using Blog.Application.Services.Articles.Queries.GetById;
using Blog.Application.Services.Users.Queries.GetByPage;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

public class ArticleController : BaseController
{
    private readonly IMediator _mediator;

    public ArticleController(IMediator mediator)
    {
        _mediator = mediator;
    }

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id, 
        CancellationToken token)
    {
        var query = new GetArticleByIdQuery(id);
        var result = await _mediator.Send<GetArticleByIdResponse>(query, token);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}
