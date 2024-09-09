using Blog.Domain.Common;

namespace Blog.Application.Interfaces.Services;
public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task<Result<string>> HandleAsync(TCommand command, CancellationToken token);
}
