using Blog.Application.Interfaces.Services;

namespace Blog.Application.Services.Account.Register;

public record RegisterUserCommand(
        string Email,
        string Password,
        string UserName = "") : ICommand;