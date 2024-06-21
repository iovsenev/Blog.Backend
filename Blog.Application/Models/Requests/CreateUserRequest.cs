namespace Blog.Application.Models.Requests;

public record CreateUserRequest(
        string UserName,
        string Email,
        string Password);