using Blog.Domain.Common;
using Blog.Domain.Entity.Write;

namespace Blog.Application.Interfaces.DbAccess;
public interface IArticleRepository
{
    Task<Result<ArticleEntity>> GetByIdAsync(Guid id, CancellationToken token);
    Task<Result<int>> SaveChangesAsync(CancellationToken token);
}