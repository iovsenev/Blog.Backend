using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using Blog.Domain.ValueObject;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.DbAccess;
public interface IUserRepository
{
    Task<Result<Guid, Error>> AddAsync(UserEntity user, CancellationToken token);
    Task<Result<UserEntity, Error>> GetByEmailAsync(EmailAddress email, CancellationToken token);
    Task<Result<int, Error>> SaveChangesAsync(CancellationToken token);
}