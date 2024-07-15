using Blog.Domain.Common;
using CSharpFunctionalExtensions;

namespace Blog.Application.Interfaces.Services;
public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task<Result<string, Error>> HandleAsync(TCommand command, CancellationToken token);
}
