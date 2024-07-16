using Blog.Application.Helpers;
using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Services.Account.Login;
public class LoginUserHandler : ICommandHandler<LoginUserCommand>
{
    private readonly IUserRepository _repository;
   private readonly CustomTokenHandler _tokenHandler;

    public LoginUserHandler(IUserRepository repository, CustomTokenHandler tokenHandler)
    {
        _repository = repository;
        _tokenHandler = tokenHandler;
    }

    public async Task<Result<string, Error>> HandleAsync(LoginUserCommand command, CancellationToken cancelationToken)
    {
        var userResult = await _repository.GetByEmailAsync(command.Email, cancelationToken);

        if (userResult.IsFailure)
            return userResult.Error;

        var user = userResult.Value;

        if (!BCrypt.Net.BCrypt.EnhancedVerify(command.Password, user.PasswordHash))
            return ErrorFactory.General.InValid("Password is not valid");

        var token = _tokenHandler.CreateToken(user);

        return token;
    }
}
