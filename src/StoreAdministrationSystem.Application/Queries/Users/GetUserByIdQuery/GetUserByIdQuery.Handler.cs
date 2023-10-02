using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.ReadModel;
using StoreAdministrationSystem.ReadModel.Users;

namespace StoreAdministrationSystem.Application.Queries.Users;

public sealed partial class GetUserByIdQuery
{
    public class Handler : IQueryHandler<
        GetUserByIdQuery,
        Results.SuccessResult,
        Results.FailResult>
    {
        private readonly IReadModelQueryExecutor _modelQueryExecutor;
        private readonly IReadModelQueryProvider<UserModelItem> _userModelProvider;
        private readonly IReadModelQueryProvider<UserSchoppingCartPositionModelItem> _userShoppingCartModelProvider;
        private readonly IReadModelQueryProvider<UserDocumentModelItem> _userDoucmentModelProvider;

        public Handler(IReadModelQueryExecutor modelQueryExecutor, 
            IReadModelQueryProvider<UserModelItem> userModelProvider,
            IReadModelQueryProvider<UserSchoppingCartPositionModelItem> userShoppingCartModelProvider,
            IReadModelQueryProvider<UserDocumentModelItem> userDoucmentModelProvider)
        {
            _modelQueryExecutor = modelQueryExecutor;
            _userModelProvider = userModelProvider;
            _userShoppingCartModelProvider = userShoppingCartModelProvider;
            _userDoucmentModelProvider = userDoucmentModelProvider;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userQuery = from u in _userModelProvider.Queryable
                            where u.UserId == request.UserId
                            select new
                            {
                                UserId = u.UserId,
                                Login = u.Login,
                                Email = u.Email,
                                IsAdmin = u.isAdmin,
                                CreateDate = u.CreateDate,
                                UpdateDate = u.UpdateDate
                            };

            var user = await _modelQueryExecutor.FirstOrDefaultAsync(userQuery, cancellationToken);

            if (user is null)
                return NotFound();

            var userSchoppingCartPositionQuery = from uscp in _userShoppingCartModelProvider.Queryable
                                                  where uscp.UserId == request.UserId
                                                  select new
                                                  {
                                                      ProductId = uscp.ProductId,
                                                      ProductCount = uscp.ProductCount,
                                                      TotalPrice = uscp.TotalPrice
                                                  };

            var userSchoppingCartPositions = await _modelQueryExecutor.ToListAsync(userSchoppingCartPositionQuery, cancellationToken);

            var userDocumentQuery = from ud in _userDoucmentModelProvider.Queryable
                                    where ud.UserId == request.UserId
                                    select new
                                    {
                                        DocumentId = ud.DocumentId,
                                        DocumentType = ud.DocumentType
                                    };

            var userDocuments = await _modelQueryExecutor.ToListAsync(userDocumentQuery, cancellationToken);

            return Success(new()
            {
                UserId = user.UserId,
                Login = user.Login,
                Email = user.Email,
                IsAdmin = user.IsAdmin,
                SchoppingCartPositionList = userSchoppingCartPositions == null ? Array.Empty<Results.UserReference.UserSchoppingCartPositionReference>() :
                    userSchoppingCartPositionQuery.Select(schoppingCartPosition => new Results.UserReference.UserSchoppingCartPositionReference()
                    {
                        ProductCount = schoppingCartPosition.ProductCount,
                        ProductId = schoppingCartPosition.ProductId
                    }),
                DocumentList = userDocuments == null ? Array.Empty<Results.UserReference.UserDocumentReference>() :
                    userDocuments.Select(document => new Results.UserReference.UserDocumentReference()
                    {
                        DocumentId = document.DocumentId,
                        DocumentType = document.DocumentType
                    }),
                CreateDate = user.CreateDate,
                UpdateDate = user.UpdateDate
            });
        }
    }
}
