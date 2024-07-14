using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Services.Account.Login;
public class LoginHandler : ICommandHandler<LoginRequest>
{
    private readonly IUserRepository _repository;

    public LoginHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid, Error>> HandleAsync(LoginRequest command, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
