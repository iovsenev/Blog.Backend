using Blog.Api.Controllers.Common;
using Blog.Application.Interfaces.Services;
using Blog.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers;
public class UserController : BaseController
{
    IWriteUserService _writeUserService;
    IReadUserService _readUserService;

    public UserController(
        IWriteUserService writeService,
        IReadUserService readService)
    {
        _readUserService = readService;
        _writeUserService = writeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery]
        GetEntityModelByPageRequest request, 
        CancellationToken token)
    {
        var entities = await _readUserService.GetAllUserByPageAsync(request, token);

        if(entities.IsFailure)
            return BadRequest(entities.Error);

        return Ok(entities.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserRequest request,
        CancellationToken token)
    {
        var result = await _writeUserService.CreateUserAsync(request, token);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> PostArticle(
        [FromBody]
        CreateArticleRequest request,
        CancellationToken token)
    {
        var result = await _writeUserService.CreateArticleAsync(request, token);
        if (result.IsFailure)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken token)
    {
        var result = await _readUserService.GetUserByIdAsync(id, token);

        if (result.IsFailure)
            return BadRequest(result.Error);
        return Ok(result.Value);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> PostComment(
        [FromBody]
        CreateCommentRequest request,
        CancellationToken token)
    {
        var result = await _writeUserService.CreateCommentAsync(request, token);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}

