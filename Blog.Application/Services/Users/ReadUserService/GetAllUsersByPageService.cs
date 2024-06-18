using Blog.Application.EntityExtensions;
using Blog.Application.Interfaces;
using Blog.Application.Interfaces.Services;
using Blog.Application.Models;
using Blog.Domain.Common;
using Blog.Domain.Entity.Read;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Users.GetAllUser;
public class GetAllUsersByPageService : IReadUserService
{
    private readonly IReadDbContext _context;

    public GetAllUsersByPageService(IReadDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAllUsersByPageResponse, Error>> GetAllUserByPage(
        GetEntityModelByPageRequest request,
        CancellationToken token)
    {
        var users = _context.Users;

        var count = users.Count();

        var result = await users
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(u => u.ToShortViewModel())
            .ToListAsync();

        return new GetAllUsersByPageResponse(result, count);
    }

    public async Task<Result<UserDto, Error>> GetUserById(Guid id, CancellationToken token)
    {
        if (id.Equals(Guid.Empty))
            return ErrorFactory.General.InValid($"This id: {id} is not valid");

        var entity = await _context.Users
            .Include(u => u.Articles)
            .Include(u => u.Comments)
            .FirstOrDefaultAsync(u => u.Id == id, token);

        if (entity is null)
            return ErrorFactory.General.NotFound($"Entity with id: {id} not found.");

        return entity;
    }
}
