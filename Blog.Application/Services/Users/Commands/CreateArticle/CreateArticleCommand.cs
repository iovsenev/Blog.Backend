using Blog.Application.Interfaces.Services;

namespace Blog.Application.Services.Users.Commands.CreateArticle;

public record CreateArticleCommand(
    Guid AuthorId,
    string Title,
    string Description,
    string Text,
    ICollection<string> Tags) : ICommand;