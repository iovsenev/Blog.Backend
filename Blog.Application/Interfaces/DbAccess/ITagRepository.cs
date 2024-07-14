using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.DbAccess;
public interface ITagRepository
{
    Task<Result<TagEntity, Error>> GetByTagNameAsync(string tagName, CancellationToken ct);
}