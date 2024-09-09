using Blog.Application.Models;
using Blog.Domain.Common;
using Blog.Domain.Entity.Read;

namespace Blog.Application.Interfaces.DbAccess;
public interface IArticleReadRepository
{
    Task<ICollection<ArticleReadModel>> GetAllNonPublish(CancellationToken cancellationToken);
    Task<(ICollection<ArticleReadModel>, int)> GetAllPublish(GetByPage paging, CancellationToken cancellationToken);
    Task<Result<ArticleReadModel>> GetByIdAsync(Guid id, CancellationToken cancelationToken);
}