namespace Blog.Application.Models.ViewModels;

public record ArticleShortModelForUser(
    Guid Id,
    string Title,
    string Description,
    DateTimeOffset CreatedDate);
