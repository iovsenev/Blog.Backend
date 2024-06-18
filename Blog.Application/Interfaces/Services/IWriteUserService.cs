using Blog.Application.Services.Users.Create.Requests;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.Services;
public interface IWriteUserService
{
    Task<Result<Guid, Error>> CreateUser(CreateUserRequest request, CancellationToken token);
    Task<Result<Guid, Error>> CreateArticle(CreateArticleRequest request, CancellationToken token);
}