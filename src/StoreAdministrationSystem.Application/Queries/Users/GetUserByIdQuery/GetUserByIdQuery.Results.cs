using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Application.Queries.Users.GetUserByIdQuery;

public sealed partial class GetUserByIdQuery
{
    private static Results.SuccessResult Success(UserReference user)
        => new(user);

    private static Results.FailResult NotFound()
        => new(ApplicationErrorCodes.USER_NOT_FOUND, "User not found");

    public static class Results
    {
        public sealed class SuccessResult : ISuccessQueryResult
        {
            public SuccessResult(UserReference user)
                => User = user;

            public UserReference User { get; init; } = null!;
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
    }

    public sealed class UserReference
    {
        public Guid UserId { get; init; }
        public string Login { get; init; } = null!;
        public string Email { get; init; } = null!;
        public bool IsAdmin { get; init; }
        public IEnumerable<UserSchoppingCartPositionReference> SchoppingCartPositionList { get; init; } = null!;
        public IEnumerable<UserDocumentReference> DocumentList { get; init; } = null!;
        public DateTimeOffset CreateDate { get; init; }
        public DateTimeOffset UpdateDate { get; init; }

        public sealed class UserSchoppingCartPositionReference
        {
            public Guid ProductId { get; init; }
            public int ProductCount { get; init; }
            public decimal TotalPrice { get; init; }
        }

        public sealed class UserDocumentReference
        {
            public Guid DocumentId { get; init; }
            public string DocumentType { get; init; } = null!;
        }
    }
}
