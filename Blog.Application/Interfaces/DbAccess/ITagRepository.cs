using Blog.Domain.Common;
using Blog.Domain.Entity.Write;

namespace Blog.Application.Interfaces.DbAccess;
public interface ITagRepository
{
    Task<Result<TagEntity>> GetByTagNameAsync(string tagName, CancellationToken ct);
}