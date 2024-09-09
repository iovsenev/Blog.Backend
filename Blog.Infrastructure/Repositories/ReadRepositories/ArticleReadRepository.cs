using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Models;
using Blog.Domain.Common;
using Blog.Domain.Entity.Read;
using Blog.Infrastructure.DbContexts;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories.ReadRepositories;
public class ArticleReadRepository : IArticleReadRepository
{
    private readonly ReadDbContext _context;
    private readonly SqlConnectionFactory _connectionFactory;

    public ArticleReadRepository(ReadDbContext context, SqlConnectionFactory connectionFactory)
    {
        _context = context;
        _connectionFactory = connectionFactory;
    }

    public async Task<(ICollection<ArticleReadModel>, int)> GetAllPublish
        (GetByPage paging,
        CancellationToken cancellationToken)
    {
        var articles = _context.Articles
            .Include(a => a.Author)
            .Where(x => x.IsPublished == true);

        var count = articles.Count();

        var result = await articles
            .Skip((paging.PageIndex - 1) * paging.PageSize)
            .Take(paging.PageSize)
            .ToListAsync();

        return (result, count);
    }

    public async Task<ICollection<ArticleReadModel>> GetAllNonPublish(CancellationToken cancellationToken)
    {
        var articles = await _context.Articles
            .Include(a => a.Author)
            .Where(x => x.IsPublished == false)
            .ToListAsync();

        return articles;
    }

    public async Task<Result<ArticleReadModel>> GetByIdAsync(Guid id, CancellationToken cancelationToken)
    {
        using var connection = _connectionFactory.CreateConnection();

        var query = $"""
                    SELECT
                    	a.id id, 
                    	a.title,
                    	a.description, 
                        a.content,
                    	a.created_at createdDate,
                    	u.id id,
                    	u.user_name userName,
                    	u.register_date registerDate,
                    	ch.id id,
                    	ch.content,
                        ch.create_date createDate,
                    	ch.author_id  id,
                    	ch.user_name userName,
                    	ch.register_date registerDate
                    FROM articles a 
                    JOIN users u ON u.id = a.author_id
                    LEFT JOIN ( 
                    	SELECT 
                    		c.id,	
                    		c.article_id,
                    		c.content,
                            c.create_date,
                    		u2.id  author_id,
                    		u2.user_name,
                    		u2.register_date 
                    	FROM "comments" c 
                    	JOIN users u2 on u2.id = c.author_id)ch on ch.article_id = a.id 
                    WHERE a.id = '{id}'
                    """;

        Dictionary<Guid, ArticleReadModel> dictionaryArticle = new();

        var article = await connection.QueryAsync<
                        ArticleReadModel,
                        UserReadModel,
                        CommentReadEntity,
                        UserReadModel,
                        ArticleReadModel>(
            query,
            (article, user, comment, comment_user) =>
            {
                if (dictionaryArticle.TryGetValue(article.Id, out var existingArticle))
                    article = existingArticle;
                else
                    dictionaryArticle.Add(article.Id, article);

                article.Author = user;

                if (comment != null)
                {
                    comment.Author = comment_user;
                    article.Comments.Add(comment);
                }

                return article;
            },
            splitOn: "id,id,id,id");

        return !dictionaryArticle.ContainsKey(id)
            ? Error.NotFound($"The article with id: {id} not found")
            : dictionaryArticle[id];
    }
}
