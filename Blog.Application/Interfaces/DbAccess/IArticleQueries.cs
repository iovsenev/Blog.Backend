using Blog.Domain.Common;
using Blog.Domain.Entity.Read;

namespace Blog.Application.Interfaces.DbAccess;
public interface IArticleQueries
{
    Task<Result<ArticleReadModel>> GetByIdAsync(Guid id, CancellationToken token);
}