using Microsoft.Extensions.Logging;
using OneOf;
using OneOf.Types;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.ReadModel;
using StoreAdministrationSystem.ReadModel.ProductCategories;

namespace StoreAdministrationSystem.Application.Queries.GetPagedProductCategoriesListQuery;

public sealed partial class GetPagedProductCategoriesListQuery
{
    public sealed class Handler : IQueryHandler<
        GetPagedProductCategoriesListQuery,
        Results.SuccessResult,
        Results.FailResults>
    {
        private readonly IReadModelQueryExecutor _readModelQueryExecutor;
        private readonly IReadModelQueryProvider<ProductCategoryModelItem> _productCategoryModelProvider;
        private readonly ILogger _logger;

        public Handler(IReadModelQueryExecutor readModelQueryExecutor,
            IReadModelQueryProvider<ProductCategoryModelItem> productCategoryModelProvider,
            ILogger<Handler> logger)
        {
            _readModelQueryExecutor = readModelQueryExecutor;
            _productCategoryModelProvider = productCategoryModelProvider;
            _logger = logger;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResults>> Handle(GetPagedProductCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = _productCategoryModelProvider.Queryable;

            if (request.Name is not null)
                query = query.Where(pc => pc.Name == request.Name);

            if (request.ProductCategoryId is not null)
                query = query.Where(pc => pc.ProductCategoryId == request.ProductCategoryId);

            var total = await _readModelQueryExecutor.CountAsync(query, cancellationToken);
            if (total == 0)
                return Success(Page<Results.ProductCatogoryReference>.Empty(request.Offset));

            var resultQuery = from pc in query
                              select new Results.ProductCatogoryReference
                              {
                                  ProductCategoryId = pc.ProductCategoryId,
                                  Name = pc.Name,
                                  CreateDate = pc.CreateDate,
                                  UpdateDate = pc.UpdateDate
                              };

            resultQuery = resultQuery
                .OrderByDescending(pc => pc.UpdateDate)
                .Skip(request.Offset)
                .Take(request.Count);

            var items = await _readModelQueryExecutor.ToListAsync(resultQuery, cancellationToken);

            return Success(items.AsPage(total, request.Offset));
        }
    }
}
