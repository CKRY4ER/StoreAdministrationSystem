using OneOf;

namespace StoreAdministrationSystem.Application.Framework;

public interface ICommandExecutor
{
    public Task<OneOf<TSuccessCommandResult, TFailCommandResult>> ExecuteAsync<TCommand, TSuccessCommandResult, TFailCommandResult>(TCommand command, CancellationToken cancellationToken = default(CancellationToken))
        where TCommand : class, ICommand<TSuccessCommandResult, TFailCommandResult>
        where TSuccessCommandResult : class, ISuccessCommandResult
        where TFailCommandResult : class, IFailCommandResult;
}
