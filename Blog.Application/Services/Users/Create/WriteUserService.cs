using Blog.Application.Interfaces;
using Blog.Application.Interfaces.Services;
using Blog.Application.Services.Users.Create.Requests;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using CSharpFunctionalExtensions;

namespace Blog.Application.Services.Users.Create;
public class WriteUserService : IWriteUserService
{
    private readonly IUserRepository _repository;

    public WriteUserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid, Error>> CreateUser(CreateUserRequest request, CancellationToken token)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var entityResult = UserEntity.Create(
            request.UserName,
            request.Email,
            passwordHash);

        if (entityResult.IsFailure)
            return entityResult.Error;

        var result = await _repository.Add(entityResult.Value, token);

        if (result.IsFailure)
            return result.Error;

        return result.Value;
    }

    public async Task<Result<Guid, Error>> CreateArticle(CreateArticleRequest request, CancellationToken token)
    {
        return Guid.NewGuid();
    }
}
