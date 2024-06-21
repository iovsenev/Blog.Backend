namespace Blog.Application.Models.Requests;

public record CreateArticleRequest(
    Guid AuthorId,
    string Title,
    string Description,
    string Text,
    ICollection<string> Tags);