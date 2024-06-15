using Blog.Application.Interfaces.Services;
using Blog.Application.Services.Users.Create;
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
    private readonly ReadDbContext _readContext;

    public UserController(WriteDbContext writeContext, ReadDbContext readContext)
    {
        _readContext = readContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entites = await _readContext.Users.ToListAsync();

        return Ok(entites);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] IUserService<CreateUserRequest, Guid> userService,
        [FromBody] CreateUserRequest request,
        CancellationToken token)
    {

        var result = await userService.Handle(request, token);

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}

