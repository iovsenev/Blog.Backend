using Blog.Application.EntityExtensions;
using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Services.Articles.Queries.GetAll;
public class GetArticlesByPageQueryHandler 
    : IQueryHandler<GetArticlesByPageQuery, GetArticlesByPageResponse>
{
    private readonly IArticleReadRepository _repository;

    public GetArticlesByPageQueryHandler(IArticleReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetArticlesByPageResponse, Error>> HandleAsync(
        GetArticlesByPageQuery query, 
        CancellationToken token)
    {
        var entityResult = await _repository.GetAllPublish(new(query.PageIndex, query.PageSize), token);

        var articles = entityResult.Item1
            .Select(a => a.ToShortViewModel())
            .ToList();

        var count = entityResult.Item2;


        return new GetArticlesByPageResponse(articles, count);
    }
}
