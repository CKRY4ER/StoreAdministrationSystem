using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Users.GetPagedUserListQuery;

public sealed partial class GetPagedUserListQuery : IQuery<
    GetPagedUserListQuery.Results.SuccessResult,
    GetPagedUserListQuery.Results.FailResult>
{
    public int Offset { get; init; }
    public int Count { get; init; }
    public Guid? UserId { get; init; } = null;
}
