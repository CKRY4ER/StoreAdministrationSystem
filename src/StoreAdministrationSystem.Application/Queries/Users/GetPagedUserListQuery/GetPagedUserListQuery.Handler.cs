using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.ReadModel;
using StoreAdministrationSystem.ReadModel.Users;

namespace StoreAdministrationSystem.Application.Queries.Users;

public sealed partial class GetPagedUserListQuery
{
    public sealed class Handler : IQueryHandler<
        GetPagedUserListQuery,
        Results.SuccessResult,
        Results.FailResult>
    {
        private readonly IReadModelQueryExecutor _modelQueryExecutor;
        private readonly IReadModelQueryProvider<UserModelItem> _userModelProvider;

        public Handler(IReadModelQueryExecutor modelQueryExecutor,
            IReadModelQueryProvider<UserModelItem> userModelProvider)
        {
            _modelQueryExecutor = modelQueryExecutor;
            _userModelProvider = userModelProvider;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetPagedUserListQuery request, CancellationToken cancellationToken)
        {
            var query = _userModelProvider.Queryable;

            if (request.UserId is not null)
                query = query.Where(user => user.UserId == request.UserId);

            var total = await _modelQueryExecutor.CountAsync(query, cancellationToken);

            if (total == 0)
                return Success(Page<Results.UserReference>.Empty(request.Offset));

            var resultQuery = from u in query
                              select new Results.UserReference()
                              {
                                  UserId = u.UserId,
                                  Login = u.Login,
                                  Email = u.Email,
                                  IsAdmin = u.isAdmin,
                                  CreateDate = u.CreateDate,
                                  UpdateDate = u.UpdateDate
                              };

            resultQuery = resultQuery
                .OrderByDescending(p => p.UpdateDate)
                .Skip(request.Offset)
                .Take(request.Count);

            var items = await _modelQueryExecutor.ToListAsync(resultQuery, cancellationToken);

            return Success(items.AsPage(total, request.Offset));
        }
    }
}
