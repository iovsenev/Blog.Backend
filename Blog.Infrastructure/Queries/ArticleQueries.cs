using Blog.Application.Interfaces;
using Blog.Application.Models.ViewModels;
using Blog.Domain.Common;
using Blog.Domain.Entity.Read;
using Blog.Infrastructure.DbContexts;
using CSharpFunctionalExtensions;
using Dapper;

namespace Blog.Infrastructure.Queries;
public class ArticleQueries : IArticleQueries
{
    private readonly SqlConnectionFactory _connectionFactory;

    public ArticleQueries(SqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    
    public async Task<Result<ArticleDto, Error>> GetByIdAsync(Guid id, CancellationToken token)
    {
        using var connection = _connectionFactory.CreateConnection();

        var query = $"""
                    SELECT
                    	a.id id, 
                    	a.title,
                    	a.description, 
                    	a.created_at,
                    	u.id id,
                    	u.user_name,
                    	u.register_date,
                    	ch.id id,
                    	ch."text",
                    	ch.author_id  id,
                    	ch.user_name,
                    	ch.register_date 
                    FROM articles a 
                    JOIN users u ON u.id = a.author_id
                    LEFT JOIN ( 
                    	SELECT 
                    		c.id,	
                    		c.article_id,
                    		c."text",
                            c.create_date,
                    		u2.id  author_id,
                    		u2.user_name,
                    		u2.register_date 
                    	FROM "comments" c 
                    	JOIN users u2 on u2.id = c.author_id)ch on ch.article_id = a.id 
                    WHERE a.id = '{id}'
                    """;

        Dictionary<Guid, ArticleDto> dictionaryArticle = new();

        var article = await connection.QueryAsync<
                        ArticleDto,
                        UserDto,
                        CommentDto,
                        UserDto,
                        ArticleDto>(
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
            ? ErrorFactory.General.NotFound($"The article with id: {id} not found")
            : dictionaryArticle[id];
    }
}
