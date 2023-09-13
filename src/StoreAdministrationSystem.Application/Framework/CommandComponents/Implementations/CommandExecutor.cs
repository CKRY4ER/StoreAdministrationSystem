using MediatR;
using OneOf;

namespace StoreAdministrationSystem.Application.Framework;

internal sealed class CommandExecutor : ICommandExecutor
{
    private readonly IMediator _mediator;

    public CommandExecutor(IMediator mediator)
    {
        _mediator = mediator;
    }

    async Task<OneOf<TSuccessCommandResult, TFailCommandResult>> ICommandExecutor.ExecuteAsync<TCommand, TSuccessCommandResult, TFailCommandResult>(TCommand command, CancellationToken cancellationToken)
        => await _mediator.Send((IRequest<OneOf<TSuccessCommandResult, TFailCommandResult>>)command, cancellationToken);
}
