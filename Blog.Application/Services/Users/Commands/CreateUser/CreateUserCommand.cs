using Blog.Application.Interfaces.Services;

namespace Blog.Application.Services.Users.Commands.CreateUser;

public record CreateUserCommand(
        string UserName,
        string Email,
        string Password) : ICommand;