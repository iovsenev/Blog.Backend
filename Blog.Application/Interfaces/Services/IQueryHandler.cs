using Blog.Domain.Common;

namespace Blog.Application.Interfaces.Services;
public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery
{
    Task<Result<TResponse>> HandleAsync(TQuery query, CancellationToken token);
}
