using Blog.Application.EntityExtensions;
using Blog.Application.Interfaces.DbAccess;
using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;

namespace Blog.Application.Services.Articles.Queries.GetById;
public class GetArticleByIdQueryHandler : IQueryHandler<GetArticleByIdQuery, GetArticleByIdResponse>
{
    private readonly IArticleReadRepository _repository;

    public GetArticleByIdQueryHandler(IArticleReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetArticleByIdResponse>> HandleAsync(GetArticleByIdQuery query, CancellationToken token)
    {
        
        var articleResult = await _repository.GetByIdAsync(query.Id, token);

        if (articleResult.IsFailure || articleResult.Value is null)
            return articleResult.Error;

        return new GetArticleByIdResponse(articleResult.Value.ToFullViewModel());
    }
}
