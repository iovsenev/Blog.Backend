using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using CSharpFunctionalExtensions;

namespace Blog.Application.Services.Users.Commands.CreateUser;
public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    private readonly IAuthorRepository _repository;

    public CreateUserCommandHandler(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid, Error>> HandleAsync(CreateUserCommand command, CancellationToken token)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(command.Password);

        var entityResult = UserEntity.Create(
            command.UserName,
            command.Email,
            passwordHash);

        if (entityResult.IsFailure)
            return entityResult.Error;

        var result = await _repository.AddAsync(entityResult.Value, token);

        if (result.IsFailure)
            return result.Error;

        return result.Value;
    }
}
