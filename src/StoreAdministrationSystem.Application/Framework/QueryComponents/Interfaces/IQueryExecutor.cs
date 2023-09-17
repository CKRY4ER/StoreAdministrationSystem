using OneOf;

namespace StoreAdministrationSystem.Application.Framework;

public interface IQueryExecutor
{
    Task<OneOf<TSuccessQueryResult, TFailQueryResult>> ExecuteAsync<TQuery, TSuccessQueryResult, TFailQueryResult>(TQuery query, CancellationToken cancellationToken)
        where TQuery : class, IQuery<TSuccessQueryResult, TFailQueryResult>
        where TSuccessQueryResult : class, ISuccessQueryResult
        where TFailQueryResult : class, IFailQueryResult;
}
