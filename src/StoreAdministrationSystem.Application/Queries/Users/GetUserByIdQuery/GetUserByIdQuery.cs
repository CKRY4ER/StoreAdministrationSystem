using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Users.GetUserByIdQuery;

public sealed partial class GetUserByIdQuery : IQuery<
    GetUserByIdQuery.Results.SuccessResult,
    GetUserByIdQuery.Results.FailResult>
{
    public Guid UserId { get; init; }
}
