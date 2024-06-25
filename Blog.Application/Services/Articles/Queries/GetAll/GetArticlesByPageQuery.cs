using Blog.Application.Interfaces.Services;

namespace Blog.Application.Services.Articles.Queries.GetAll;

public record GetArticlesByPageQuery(
    int PageIndex = 1,
    int PageSize = 10) : IQuery;