using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.Services;
public interface IUserService<TRequest, TResponse>
{
    Task<Result<TResponse, Error>> Handle(TRequest request, CancellationToken token);
}