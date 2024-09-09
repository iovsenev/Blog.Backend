using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;

namespace Blog.Application.Services.Account.Register;
public class RegisterUserHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _repository;
    public RegisterUserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> HandleAsync(RegisterUserCommand command, CancellationToken token)
    {
        var isUnique = await _repository.IsUniqueUser(command.UserName, command.Email, token);
        if (!isUnique.IsSuccess)
            return Error.AlreadyExists($"User with email or user name already exist.");

        var role = await _repository.GetRole(nameof(RoleEntity.User.Name), token);

        var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(command.Password);

        var entityResult = UserEntity.Create(
            command.Email,
            passwordHash,
            command.UserName
            );

        if (entityResult.IsFailure || entityResult.Value is  null)
            return entityResult.Error;

        var result = await _repository.AddAsync(entityResult.Value, token);

        if (result.IsFailure)
            return result.Error;

        return result.Value.ToString();
    }
}
