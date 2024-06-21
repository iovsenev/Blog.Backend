using Blog.Domain.Common;
using Blog.Domain.Entity.Read;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces;
public interface IArticleQueries
{
    Task<Result<ArticleDto, Error>> GetByIdAsync(Guid id, CancellationToken token);
}