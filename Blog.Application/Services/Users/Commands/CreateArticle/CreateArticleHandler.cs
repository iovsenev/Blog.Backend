using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using CSharpFunctionalExtensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Blog.Application.Services.Users.Commands.CreateArticle;
public class CreateArticleHandler : ICommandHandler<CreateArticleCommand>
{
    private readonly IAuthorRepository _repository;
    private readonly ITagRepository _tagRepository;

    public CreateArticleHandler(IAuthorRepository repository, ITagRepository tagRepository)
    {
        _repository = repository;
        _tagRepository = tagRepository;
    }

    public async Task<Result<Guid, Error>> HandleAsync(CreateArticleCommand command, CancellationToken token)
    {
        var author = await _repository.GetByIdAsync(command.AuthorId, token);
        if (author.IsFailure)
            return author.Error;

        var tags = await GetTags(command.Tags, token);
        if (tags.IsFailure)
            return tags.Error;

        var article = ArticleEntity.Create(command.Title, command.Description, command.Text, tags.Value);

        if (article.IsFailure)
            return article.Error;

        author.Value.PostArticle(article.Value);

        var result = await _repository.SaveChangesAsync(token);

        if (result.IsFailure)
            return result.Error;

        return article.Value.Id;
    }

    private async Task<Result<IEnumerable<TagEntity>, Error>> GetTags(ICollection<string> tags, CancellationToken token)
    {
        List<TagEntity> entities = new List<TagEntity>();
        foreach (var tag in tags)
        {
            if (string.IsNullOrEmpty(tag))
                return ErrorFactory.General.InValid("This tag is null or empty.");
            var tagEntityResult = await _tagRepository.GetByTagNameAsync(tag, token);

            TagEntity tagEntity;

            if (tagEntityResult.IsFailure)
            {
                var tagResult = TagEntity.Create(tag);
                if (tagResult.IsFailure)
                    return tagResult.Error;
                tagEntity = tagResult.Value;
            }
            tagEntity = tagEntityResult.Value;

            entities.Add(tagEntity);
        }
        return entities;
    }
}
