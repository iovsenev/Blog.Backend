using Blog.Application.Interfaces.DbAccess;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using Blog.Infrastructure.DbContexts;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories.WriteRepositories;

public class UserRepository : IUserRepository
{
    private readonly WriteDbContext _dbContext;

    public UserRepository(WriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<int, Error>> SaveChangesAsync(CancellationToken token)
    {
        var save = await _dbContext.SaveChangesAsync(token);

        if (save == 0)
            return ErrorFactory.General.SaveFalling("Can not be saved");

        return save;
    }

    public async Task<Result<Guid, Error>> AddAsync(UserEntity user, CancellationToken token)
    {
        var search = await _dbContext.Users.FirstOrDefaultAsync(
            u => u.Email.Equals(user.Email) || u.UserName.Equals(user.UserName),
            token);

        if (search is not null)
            return ErrorFactory.General.AlreadyExists("User with this email or user name already exist");

        await _dbContext.AddAsync(user, token);
        var save = await SaveChangesAsync(token);

        if (save.IsFailure)
            return save.Error;

        return user.Id;
    }

    public async Task<bool> IsUniqueUser(string? userName = null, string? email = null, CancellationToken token = default)
    {
        var entity = await _dbContext.Users.FirstOrDefaultAsync(
            u => u.Email.Equals(email) || u.UserName.Equals(userName),
            token);

        return entity is not null ? false : true;
    }

    public async Task<Result<UserEntity, Error>> GetByEmailAsync(string email, CancellationToken token)
    {
        var entity = await _dbContext.Users
            .Include(u => u.Role)
            .Include(u => u.Articles)
            .Include(u => u.Comments)
            .FirstOrDefaultAsync(u => u.Email == email, token);

        if (entity is null)
            return ErrorFactory.General.NotFound($"Entity with this id: {email} is not found.");

        return entity;
    }

    public async Task<Result<UserEntity, Error>> GetByIdAsync(Guid id, CancellationToken token)
    {
        var entity = await _dbContext.Users
            .Include(u => u.Role)
            .Include(u => u.Articles)
            .Include(u => u.Comments)
            .FirstOrDefaultAsync(u => u.Id == id, token);

        if (entity is null)
            return ErrorFactory.General.NotFound($"Entity with this id: {id} is not found.");

        return entity;
    }

    public async Task<Result<RoleEntity, Error>> GetRole(string roleName, CancellationToken token)
    {
        var entity = await _dbContext.Roles.FirstOrDefaultAsync(r=> r.Name.ToLower() == roleName.ToLower(), token);
        if (entity is null)
            return ErrorFactory.General.NotFound($" Role with name : {roleName} not found");

        return entity;
    }
}



