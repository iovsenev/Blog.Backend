using Blog.Application.Interfaces.DbAccess;
using Blog.Domain.Common;
using Blog.Domain.Entity.Write;
using Blog.Infrastructure.DbContexts;
namespace Blog.Infrastructure.Repositories.WriteRepositories;
public class ArticleRepository : IArticleRepository
{
    private readonly WriteDbContext _dbContext;

    public ArticleRepository(WriteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<int>> SaveChangesAsync(CancellationToken token)
    {
        var save = await _dbContext.SaveChangesAsync(token);

        if (save == 0)
            return Error.SaveFalling("Can not be saved");

        return save;
    }

    public async Task<Result<ArticleEntity>> GetByIdAsync(Guid id, CancellationToken token)
    {
        var article = await _dbContext.Articles.FindAsync(id, token);

        if (article is null)
            return Error.NotFound($"Article with id: {id} not found");

        return article;
    }
}
