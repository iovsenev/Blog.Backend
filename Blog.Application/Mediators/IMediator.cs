using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using Microsoft.AspNetCore.Identity.Data;

namespace Blog.Application.Mediators;
public interface IMediator
{
    Task<Result<TResponse>> Send<TResponse>(IQuery request, CancellationToken token = default);
    Task<Result<string>> Send(ICommand command, CancellationToken token = default);
}
