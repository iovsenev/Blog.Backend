namespace Blog.Application.Services.Users.Create.Requests;

public record CreateArticleRequest(
    Guid AuthorId,
    string Title,
    string Description,
    string Text,
    ICollection<string> Tags);