using MediatR;
using OneOf;

namespace StoreAdministrationSystem.Application.Framework;

internal interface IQueryHandler<TQuery, TSuccessQueryResult, TFailQueryResult> : IRequestHandler<TQuery, OneOf<TSuccessQueryResult, TFailQueryResult>>
    where TQuery : class, IQuery<TSuccessQueryResult, TFailQueryResult>
    where TSuccessQueryResult : class, ISuccessQueryResult
    where TFailQueryResult : class, IFailQueryResult
{
}
