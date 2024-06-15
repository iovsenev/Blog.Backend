using Blog.Application.Interfaces;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using CSharpFunctionalExtensions;

namespace Blog.Application.Services.Users.Create;
public class CreateUserService : IUserService<CreateUserRequest, Guid>
{
    private readonly IUserRepository _repository;

    public CreateUserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid, Error>> Handle(CreateUserRequest request, CancellationToken token)
    {
        var paswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var entityResult = UserEntity.Create(
            request.UserName,
            request.Email,
            paswordHash);

        if (entityResult.IsFailure)
            return entityResult.Error;

        var result = await _repository.Add(entityResult.Value, token);

        if (result.IsFailure)
            return result.Error;

        return result.Value;
    }
}
