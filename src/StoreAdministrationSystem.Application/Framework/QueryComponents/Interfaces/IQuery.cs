using MediatR;
using OneOf;

namespace StoreAdministrationSystem.Application.Framework;

public interface IQuery<TSuccessQueryResult, TFailQueryResult> : IRequest<OneOf<TSuccessQueryResult, TFailQueryResult>>
    where TSuccessQueryResult : class, ISuccessQueryResult
    where TFailQueryResult : class, IFailQueryResult
{
}
