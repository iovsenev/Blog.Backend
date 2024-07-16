using Blog.Application.Models;
using Blog.Domain.Common;
using Blog.Domain.Entity.Read;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.DbAccess;
public interface IArticleReadRepository
{
    Task<ICollection<ArticleReadModel>> GetAllNonPublish(CancellationToken cancellationToken);
    Task<(ICollection<ArticleReadModel>, int)> GetAllPublish(GetByPage paging, CancellationToken cancellationToken);
    Task<Result<ArticleReadModel, Error>> GetByIdAsync(Guid id, CancellationToken cancelationToken);
}