using MediatR;
using OneOf;

namespace StoreAdministrationSystem.Application.Framework;

internal sealed class QueryExecutor : IQueryExecutor
{
    private readonly IMediator _mediator;

    public QueryExecutor(IMediator mediator)
    {
        _mediator = mediator;
    }

    async Task<OneOf<TSuccessQueryResult, TFailQueryResult>> IQueryExecutor.ExecuteAsync<TQuery, TSuccessQueryResult, TFailQueryResult>(TQuery query, CancellationToken cancellationToken)
        => await _mediator.Send((IRequest<OneOf<TSuccessQueryResult, TFailQueryResult>>)query, cancellationToken);
}
