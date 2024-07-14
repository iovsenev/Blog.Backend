using Blog.Application.Interfaces.DbAccess;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using Blog.Infrastructure.DbContexts;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories;
public class AuthorRepository : IAuthorRepository
{
    private readonly WriteDbContext _dbContext;

    public AuthorRepository(WriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<int, Error>> SaveChangesAsync(CancellationToken token)
    {
        var save = await _dbContext.SaveChangesAsync(token);

        if (save == 0)
            return ErrorFactory.General.SaveFalling("Can not be seved");

        return save;
    }

    public async Task<Result<Guid, Error>> AddAsync(UserEntity user, CancellationToken token)
    {
        var search = await _dbContext.Authors.FirstOrDefaultAsync(
            u =>
                u.UserName.Equals(user.UserName)
                || u.Id == user.Id,
            token);

        if (search is not null)
            return ErrorFactory.General.AlreadyExists("User with this email or user name already exist");

        await _dbContext.AddAsync(user, token);
        var save = await SaveChangesAsync(token);

        if (save.IsFailure)
            return save.Error;

        return user.Id;
    }

    public async Task<Result<UserEntity, Error>> GetByIdAsync(Guid id, CancellationToken token)
    {
        var entity = await _dbContext.Authors.FindAsync(id, token);

        if (entity is null)
            return ErrorFactory.General.NotFound($"Entity whith this id: {id} is not found.");

        return entity;
    }
}



