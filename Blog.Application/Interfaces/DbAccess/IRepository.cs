using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.DbAccess;
public interface IRepository<TEntity>
{
    Task<Result<Guid, Error>> AddAsync(TEntity user, CancellationToken token);
    Task<Result<TEntity, Error>> GetByIdAsync(Guid id, CancellationToken token);
    Task<Result<int, Error>> SaveChangesAsync(CancellationToken token);
}