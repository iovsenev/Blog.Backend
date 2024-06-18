using Blog.Application.Interfaces.Services;
using Blog.Application.Models;
using Blog.Application.Services.Users.Create.Requests;
using Blog.Application.Services.Users.GetAllUser;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using Blog.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
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
        var entities = await _readUserService.GetAllUserByPage(request, token);

        if(entities.IsFailure)
            return BadRequest(entities.Error);

        return Ok(entities.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserRequest request,
        CancellationToken token)
    {
        var result = await _writeUserService.CreateUser(request, token);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}

