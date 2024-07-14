using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using CSharpFunctionalExtensions;

namespace Blog.Application.Services.Users.Commands.CreateComment;
public class CreateCommentHandler : ICommandHandler<CreateCommentCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IArticleRepository _articleRepository;

    public CreateCommentHandler(
        IUserRepository userRepository,
        IArticleRepository articleRepository)
    {
        _userRepository = userRepository;
        _articleRepository = articleRepository;
    }

    public async Task<Result<Guid, Error>> HandleAsync(CreateCommentCommand command, CancellationToken token)
    {
        var author = await _userRepository.GetByIdAsync(command.AuthorId, token);
        if (author.IsFailure)
            return author.Error;

        var article = await _articleRepository.GetByIdAsync(command.ArticleId, token);
        if (article.IsFailure)
            return article.Error;

        var comment = CommentEntity.Create(command.Text);
        if (comment.IsFailure)
            return comment.Error;

        author.Value.PostComment(comment.Value);
        article.Value.PostComment(comment.Value);

        var result = await _userRepository.SaveChangesAsync(token);

        if (result.IsFailure)
            return result.Error;

        return comment.Value.Id;
    }
}
