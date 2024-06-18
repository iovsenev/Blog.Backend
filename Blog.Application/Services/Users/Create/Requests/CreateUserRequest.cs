namespace Blog.Application.Services.Users.Create.Requests;

public record CreateUserRequest(
        string UserName,
        string Email,
        string Password);