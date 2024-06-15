namespace Blog.Application.Services.Users.Create;

public record CreateUserRequest(
        string UserName,
        string Email,
        string Password);