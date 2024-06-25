using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.Services;
public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery
{
    Task<Result<TResponse, Error>> HandleAsync(TQuery query, CancellationToken token);
}
