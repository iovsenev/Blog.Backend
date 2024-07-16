using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Services.Admin.PublishArticle;
public class PostArticleHandler : ICommandHandler<PostArticleAdminCommand>
{
    public readonly IArticleRepository _repository;

    public PostArticleHandler(IArticleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<string, Error>> HandleAsync(PostArticleAdminCommand command, CancellationToken cancellationToken)
    {
        var entityResult = await _repository.GetByIdAsync(command.ArticleId, cancellationToken);
        if (entityResult.IsFailure)
            return entityResult.Error;

        var article = entityResult.Value;

        article.PublishArticle(command.IsPublish);
        var saved = await _repository.SaveChangesAsync(cancellationToken);
        if (saved.IsFailure)
            return saved.Error;

        return command.IsPublish ? "Article publish" : "Article not publish";
    }

}
