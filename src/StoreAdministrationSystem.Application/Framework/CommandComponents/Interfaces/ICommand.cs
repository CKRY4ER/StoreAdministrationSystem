using MediatR;
using OneOf;

namespace StoreAdministrationSystem.Application.Framework;

public interface ICommand<TSuccessResult, TFailResult> : IRequest<OneOf<TSuccessResult, TFailResult>>
    where TSuccessResult : class, ISuccessCommandResult
    where TFailResult : class, IFailCommandResult
{
}
