using Microsoft.Extensions.Logging;
using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.ReadModel;
using StoreAdministrationSystem.ReadModel.ProductCategories;

namespace StoreAdministrationSystem.Application.Queries.ProductCategories.GetProductCategoriesListQuery;

public sealed partial class GetProductCategoriesListQuery
{
    public sealed class Handler : IQueryHandler<
        GetProductCategoriesListQuery,
        Results.SuccessResult,
        Results.FailResult>
    {
        private readonly IReadModelQueryExecutor _modelQueryExecutor;
        private readonly IReadModelQueryProvider<ProductCategoryModelItem> _productCategoryModelQueryProvider;
        private readonly ILogger _logger;

        public Handler(IReadModelQueryExecutor modelQueryExecutor,
            IReadModelQueryProvider<ProductCategoryModelItem> productCategoryModelQueryProvider,
            ILogger<Handler> logger)
        {
            _modelQueryExecutor = modelQueryExecutor;
            _productCategoryModelQueryProvider = productCategoryModelQueryProvider;
            _logger = logger;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetProductCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var query = from pc in _productCategoryModelQueryProvider.Queryable
                        select new
                        {
                            ProductCategoryId = pc.ProductCategoryId,
                            Name = pc.Name
                        };

            var productCategories = await _modelQueryExecutor.ToListAsync(query, cancellationToken);

            if (productCategories.Any() is false)
                return NotFound();

            return Success(productCategories.Select(pc => new ProductCategoryReference()
            {
                ProductCategoryId = pc.ProductCategoryId,
                Name = pc.Name
            }));
        }
    }
}
