using Blog.Application.Interfaces.Services;
namespace Blog.Application.Services.Users.Queries.GetByPage;
public record GetUsersByPageQuery(
    int PageIndex = 1,
    int PageSize = 10) : IQuery;
