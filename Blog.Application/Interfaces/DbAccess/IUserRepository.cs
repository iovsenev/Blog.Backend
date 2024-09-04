using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using Blog.Domain.ValueObject;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.DbAccess;
public interface IUserRepository
{
    Task<Result<Guid, Error>> AddAsync(UserEntity user, CancellationToken token);
    Task<Result<UserEntity, Error>> GetByEmailAsync(string email, CancellationToken token);
    Task<Result<int, Error>> SaveChangesAsync(CancellationToken token);
    Task<Result<UserEntity, Error>> GetByIdAsync(Guid id, CancellationToken token);
    Task<bool> IsUniqueUser(string? userName = null, string? email = null, CancellationToken token = default);
    Task<Result<RoleEntity, Error>> GetRole(string roleName, CancellationToken token);
}