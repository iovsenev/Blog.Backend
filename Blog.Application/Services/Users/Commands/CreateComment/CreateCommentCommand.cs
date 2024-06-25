using Blog.Application.Interfaces.Services;

namespace Blog.Application.Services.Users.Commands.CreateComment;
public record CreateCommentCommand(
    Guid AuthorId,
    Guid ArticleId,
    string Text) : ICommand;
