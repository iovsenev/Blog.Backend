using Blog.Application.EntityExtensions;
using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Articles.Queries.GetAll;
public class GetArticlesByPageQueryHandler 
    : IQueryHandler<GetArticlesByPageQuery, GetArticlesByPageResponse>
{
    private readonly IReadDbContext _context;

    public GetArticlesByPageQueryHandler(IReadDbContext readDbContext)
    {
        _context = readDbContext;
    }

    public async Task<Result<GetArticlesByPageResponse, Error>> HandleAsync(
        GetArticlesByPageQuery query, 
        CancellationToken token)
    {
        var articles = _context.Articles
            .Include(a => a.Author);

        var count = articles.Count();

        var result = await articles
            .Skip((query.PageIndex - 1) * query.PageSize)
            .Take(query.PageSize)
            .Select(u => u.ToShortViewModel())
            .ToListAsync();

        return new GetArticlesByPageResponse(result, count);
    }
}
