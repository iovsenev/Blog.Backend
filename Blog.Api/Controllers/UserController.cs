using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using Blog.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly WriteDbContext _writeContext;
    private readonly ReadDbContext _readContext;

    public UserController(WriteDbContext writeContext, ReadDbContext readContext)
    {
        _writeContext = writeContext;
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
        [FromBody] CreateUserRequest request)
    {
        var user = UserEntity.Create(
            request.userName,
            request.email,
            request.passwordHash,
            request.phoneNumber);

        if (user.IsFailure)
            return BadRequest(user.Error);

        await _writeContext.Users.AddAsync(user.Value);
        var result = await _writeContext.SaveChangesAsync();

        if (result == 0)
            return BadRequest(ErrorFactory.General.AddingFalling("bad adding"));

        return Ok();
    }
}

public record CreateUserRequest(
        string userName,
        string email,
        string passwordHash,
        string phoneNumber);