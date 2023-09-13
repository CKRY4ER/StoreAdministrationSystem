using MediatR;
using OneOf;

namespace StoreAdministrationSystem.Application.Framework;

public interface ICommandHandler<TCommand, TSuccessComandResult, TFailCommandResult> : IRequestHandler<TCommand, OneOf<TSuccessComandResult, TFailCommandResult>>
    where TCommand : class, ICommand<TSuccessComandResult, TFailCommandResult>
    where TSuccessComandResult : class, ISuccessCommandResult
    where TFailCommandResult : class , IFailCommandResult
{
}
