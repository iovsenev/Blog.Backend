using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces;
public interface IRepository<TEntity>
{
    Task<Result<Guid, Error>> Add(TEntity user, CancellationToken token);
    Task<Result<TEntity, Error>> GetById(Guid id, CancellationToken token);
    Task<Result<int, Error>> SaveChangesAsync(CancellationToken token);
}