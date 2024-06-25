using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using CSharpFunctionalExtensions;

namespace Blog.Application.Services.Users.Commands.CreateArticle;
public class CreateArticleHandler : ICommandHandler<CreateArticleCommand>
{
   private readonly IUserRepository _repository;

    public CreateArticleHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid, Error>> HandleAsync(CreateArticleCommand command, CancellationToken token)
    {
        var author = await _repository.GetByIdAsync(command.AuthorId, token);
        if (author.IsFailure)
            return author.Error;

        var article = ArticleEntity.Create(command.Title, command.Description, command.Text);

        if (article.IsFailure)
            return article.Error;

        author.Value.PostArticle(article.Value);

        var result = await _repository.SaveChangesAsync(token);

        if (result.IsFailure)
            return result.Error;

        return article.Value.Id;
    }
}
