using Blog.Application.EntityExtensions;
using Blog.Application.Interfaces;
using Blog.Application.Interfaces.Services;
using Blog.Application.Models.Requests;
using Blog.Application.Models.Responses;
using Blog.Application.Models.ViewModels;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Services.Articles.Read;
public class ReadArticleService : IReadArticleService
{
    private readonly IReadDbContext _context;
    private readonly IArticleQueries _articleQueries;

    public ReadArticleService(IReadDbContext context, IArticleQueries articleQueries)
    {
        _context = context;
        _articleQueries = articleQueries;
    }

    public async Task<Result<GetAllArticlesByPageResponse, Error>> GetAllArticlesByPageAsync(
        GetEntityModelByPageRequest request,
        CancellationToken token)
    {
        var articles = _context.Articles
            .Include(a => a.Author);

        var count = articles.Count();

        var result = await articles
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(u => u.ToShortViewModel())
            .ToListAsync();

        return new GetAllArticlesByPageResponse(result, count);
    }

    public async Task<Result<ArticleFullViewModel, Error>> GetByIdAsync(Guid id, CancellationToken token)
    {
        var articleResult = await _articleQueries.GetByIdAsync(id,token);

        if (articleResult.IsFailure)
            return articleResult.Error;

        return articleResult.Value.ToFullViewModel();
    }
}
