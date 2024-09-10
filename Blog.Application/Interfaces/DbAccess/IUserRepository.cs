using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using Blog.Domain.ValueObject;

namespace Blog.Application.Interfaces.DbAccess;
public interface IUserRepository
{
    Task<Result<Guid>> AddAsync(UserEntity user, CancellationToken token);
    Task<Result<UserEntity>> GetByEmailAsync(string email, CancellationToken token);
    Task<Result<int>> SaveChangesAsync(CancellationToken token);
    Task<Result<UserEntity>> GetByIdAsync(Guid id, CancellationToken token);
    Task<Result> IsUniqueUser(string? userName = null, string? email = null, CancellationToken token = default);
    Task<Result<RoleEntity>> GetRole(string roleName, CancellationToken token);
    Task<Result<IEnumerable<UserEntity>>> GetAllUsersAsync(CancellationToken token);
}