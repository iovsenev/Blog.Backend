using Blog.Domain.Common;

namespace Blog.Application.Interfaces.DbAccess;
public interface IRepository<TEntity>
{
    Task<Result<Guid>> AddAsync(TEntity user, CancellationToken token);
    Task<Result<TEntity>> GetByIdAsync(Guid id, CancellationToken token);
    Task<Result<int>> SaveChangesAsync(CancellationToken token);
}   