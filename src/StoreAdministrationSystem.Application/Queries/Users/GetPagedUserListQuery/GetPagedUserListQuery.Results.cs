using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Users;

public sealed partial class GetPagedUserListQuery
{
    private static Results.SuccessResult Success(Page<Results.UserReference> users)
        => new(users);

    public static class Results
    {
        public sealed class SuccessResult : ISuccessQueryResult
        {
            public SuccessResult(Page<UserReference> users)
                => Users = users;

            public Page<UserReference> Users { get; init; } = null!;
        }

        public sealed class FailResult : IFailQueryResult
        {
            public FailResult(string code, string message)
            {
                Code = code;
                Message = message;
            }

            public string Code { get; init; } = null!;
            public string Message { get; init; } = null!;
        }

        public class UserReference
        {
            public Guid UserId { get; init; }
            public string Login { get; init; } = null!;
            public string Email { get; init; } = null!;
            public bool IsAdmin { get; init; }
            public DateTimeOffset CreateDate { get; init; }
            public DateTimeOffset UpdateDate { get; init; }
        }
    }
}
