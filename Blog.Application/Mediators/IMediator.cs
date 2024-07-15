using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity.Data;

namespace Blog.Application.Mediators;
public interface IMediator
{
    Task<Result<TResponse, Error>> Send<TResponse>(IQuery request, CancellationToken token = default);
    Task<Result<string, Error>> Send(ICommand command, CancellationToken token = default);
}
