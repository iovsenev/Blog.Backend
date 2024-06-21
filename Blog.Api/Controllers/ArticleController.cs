using Blog.Api.Controllers.Common;
using Blog.Application.Interfaces.Services;
using Blog.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;

public class ArticleController : BaseController
{
    private readonly IReadArticleService _readArticleService;

    public ArticleController(IReadArticleService readArticleService)
    {
        _readArticleService = readArticleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery]
        GetEntityModelByPageRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _readArticleService.GetAllArticlesByPageAsync(request, cancellationToken);

        if (response.IsFailure)
            return BadRequest(response.Error);

        return Ok(response.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(
        Guid id, 
        CancellationToken token)
    {
        var result = await _readArticleService.GetByIdAsync(id, token);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}
