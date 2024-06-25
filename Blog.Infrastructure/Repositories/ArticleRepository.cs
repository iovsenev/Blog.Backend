using Blog.Application.Interfaces.DbAccess;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using Blog.Infrastructure.DbContexts;
using CSharpFunctionalExtensions;
namespace Blog.Infrastructure.Repositories;
public class ArticleRepository : IArticleRepository
{
    private readonly WriteDbContext _dbContext;

    public ArticleRepository(WriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<ArticleEntity, Error>> GetByIdAsync(Guid id, CancellationToken token)
    {
        var article = await _dbContext.Articles.FindAsync(id, token);

        if (article == null)
            return ErrorFactory.General.NotFound($"Article with id: {id} not found");

        return article;
    }
}
