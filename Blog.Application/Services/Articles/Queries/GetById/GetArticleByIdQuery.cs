using Blog.Application.Interfaces.Services;

namespace Blog.Application.Services.Articles.Queries.GetById;

public record GetArticleByIdQuery(
    Guid Id) : IQuery;