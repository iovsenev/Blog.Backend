using Blog.Application.Interfaces;
using Blog.Application.Interfaces.Services;
using Blog.Application.Models.Requests;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using CSharpFunctionalExtensions;

namespace Blog.Application.Services.Users.Create;
public class WriteUserService : IWriteUserService
{
    private readonly IUserRepository _repository;
    private readonly IArticleRepository _articleRepository;

    public WriteUserService(
        IUserRepository repository, 
        IArticleRepository articleRepository)
    {
        _repository = repository;
        _articleRepository = articleRepository;
    }

    public async Task<Result<Guid, Error>> CreateUserAsync(CreateUserRequest request, CancellationToken token)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var entityResult = UserEntity.Create(
            request.UserName,
            request.Email,
            passwordHash);

        if (entityResult.IsFailure)
            return entityResult.Error;

        var result = await _repository.AddAsync(entityResult.Value, token);

        if (result.IsFailure)
            return result.Error;

        return result.Value;
    }

    public async Task<Result<Guid, Error>> CreateArticleAsync(
        CreateArticleRequest request, 
        CancellationToken token)
    {
        var author = await _repository.GetByIdAsync(request.AuthorId,token);
        if (author.IsFailure)
            return author.Error;

        var article = ArticleEntity.Create(request.Title, request.Description, request.Text);

        if (article.IsFailure)
            return article.Error;

        author.Value.PostArticle(article.Value);

        var result = await _repository.SaveChangesAsync(token);

        if (result.IsFailure)
            return result.Error;

        return article.Value.Id;
    }

    public async Task<Result<Guid, Error>> CreateCommentAsync(
        CreateCommentRequest request, 
        CancellationToken token)
    {
        var author = await _repository.GetByIdAsync(request.AuthorId, token);
        if (author.IsFailure)
            return author.Error;

        var article = await _articleRepository.GetByIdAsync(request.ArticleId, token);
        if (article.IsFailure)
            return article.Error;

        var comment = CommentEntity.Create(request.Text);
        if (comment.IsFailure)
            return comment.Error;

        author.Value.PostComment(comment.Value);
        article.Value.PostComment(comment.Value);
        
        var result = await _repository.SaveChangesAsync(token);

        if (result.IsFailure)
            return result.Error;

        return comment.Value.Id;
    }
}
