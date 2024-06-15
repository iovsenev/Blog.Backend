namespace Blog.Application.Models;
public record ShortUserViewModel(
    Guid id,
    string userName,
    DateTime RegisterDate,
    string? Fullname = null);
