using Blog.Application.Models.Requests;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.Services;
public interface IWriteUserService
{
    Task<Result<Guid, Error>> CreateUserAsync(CreateUserRequest request, CancellationToken token);
    Task<Result<Guid, Error>> CreateArticleAsync(CreateArticleRequest request, CancellationToken token);
    Task<Result<Guid, Error>> CreateCommentAsync(CreateCommentRequest request, CancellationToken token);
}