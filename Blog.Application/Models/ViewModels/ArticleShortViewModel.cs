namespace Blog.Application.Models.ViewModels;
public record ArticleShortViewModel(
    Guid Id,
    string Title,
    string Description,
    DateTimeOffset CreatedDate,
    ShortUserViewModel author);
