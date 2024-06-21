using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces;
public interface IArticleRepository
{
    Task<Result<ArticleEntity, Error>> GetByIdAsync(Guid id, CancellationToken token);
}