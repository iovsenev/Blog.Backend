using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace Blog.Application.Mediators;

public abstract class RequestHandlerBase
{
    public abstract Task<Result<object?>> HandleAsync(object request, IServiceProvider provider, CancellationToken token);
}

public abstract class RequestHandlerWrapper<TResponse> : RequestHandlerBase
{
    public abstract Task<Result<TResponse>> HandleAsync(IQuery request, IServiceProvider provider, CancellationToken token);
}

public abstract class RequestHandlerWrapper : RequestHandlerBase
{
    public abstract Task<Result<string>> HandleAsync(ICommand command, IServiceProvider provider, CancellationToken token);
}

public class RequestHandlerWrapperImpl<TRequest, TResponse> : RequestHandlerWrapper<TResponse> where TRequest : IQuery
{
    public override async Task<Result<object?>> HandleAsync(object request, IServiceProvider provider, CancellationToken token) =>
        await HandleAsync((TRequest)request, provider, token).ConfigureAwait(false);
    public override Task<Result<TResponse>> HandleAsync(IQuery request, IServiceProvider provider, CancellationToken token)
    {
        var service = provider.GetRequiredService<IQueryHandler<TRequest, TResponse>>();
        Task<Result<TResponse>> Handler() => service
            .HandleAsync((TRequest)request, token);
        var result = Handler();
        return result;
    }
}

public class RequestHandlerWrapperImpl<TRequest> : RequestHandlerWrapper where TRequest : ICommand
{
    public override async Task<Result<object?>> HandleAsync(object request, IServiceProvider provider, CancellationToken token) =>
        await HandleAsync((TRequest)request, provider, token).ConfigureAwait(false);
    public override Task<Result<string>> HandleAsync(ICommand command, IServiceProvider provider, CancellationToken token)
    {
        Task<Result<string>> Handler() => provider.GetRequiredService<ICommandHandler<TRequest>>()
            .HandleAsync((TRequest)command, token);

        var result = Handler();
        return result;
    }


}