using Blog.Application.Interfaces.Services;
using Blog.Domain.Common;
using CSharpFunctionalExtensions;
using System.Collections.Concurrent;
using System.Threading;

namespace Blog.Application.Mediators;
public class Mediator : IMediator
{
    private readonly IServiceProvider _provider;
    private static readonly ConcurrentDictionary<Type, RequestHandlerBase> _requestHandlers = new();

    public Mediator(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task<Result<TResponse, Error>> Send<TResponse>(IQuery request, CancellationToken token = default)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var handler = (RequestHandlerWrapper<TResponse>)_requestHandlers.GetOrAdd(request.GetType(), requestType =>
        {
            var wrapperType = typeof(RequestHandlerWrapperImpl<,>).MakeGenericType(requestType, typeof(TResponse));
            var wrapper = Activator.CreateInstance(wrapperType) ?? throw new InvalidOperationException($"Could not create wrapper type for {requestType}");
            return (RequestHandlerBase)wrapper;
        });

        return await handler.HandleAsync(request, _provider, token);
    }

    public async Task<Result<string, Error>> Send(ICommand command, CancellationToken token = default)
    {
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var handler = (RequestHandlerWrapper)_requestHandlers.GetOrAdd(command.GetType(), requestType =>
        {
            var wrapperType = typeof(RequestHandlerWrapperImpl<>).MakeGenericType(requestType);
            var wrapper = Activator.CreateInstance(wrapperType) 
            ?? throw new InvalidOperationException($"Could not create wrapper type for {requestType}");
            return (RequestHandlerBase)wrapper;
        });

        return await handler.HandleAsync(command, _provider, token);
    }
}
