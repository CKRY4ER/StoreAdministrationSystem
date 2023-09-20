using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.ReadModel;
using StoreAdministrationSystem.ReadModel.ProductCategories;
using StoreAdministrationSystem.ReadModel.Products;

namespace StoreAdministrationSystem.Application.Queries.Products;

public sealed partial class GetProductListQuery
{
    public sealed class Handler : IQueryHandler<
        GetProductListQuery,
        Results.SuccessResult,
        Results.FailResults>
    {
        private readonly IReadModelQueryExecutor _modelQueryExecutor;
        private readonly IReadModelQueryProvider<ProductModelItem> _productModelProvider;
        private readonly IReadModelQueryProvider<ProductCategoryModelItem> _productCategoryModelProvider;

        public Handler(IReadModelQueryExecutor modelQueryExecutor,
            IReadModelQueryProvider<ProductModelItem> productModelProvider,
            IReadModelQueryProvider<ProductCategoryModelItem> productCategoryModelProvider)
        {
            _modelQueryExecutor = modelQueryExecutor;
            _productModelProvider = productModelProvider;
            _productCategoryModelProvider = productCategoryModelProvider;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResults>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var query = from p in _productModelProvider.Queryable
                           join pc in _productCategoryModelProvider.Queryable on p.ProductCategoryId equals pc.ProductCategoryId
                           select new Results.ProductReference
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               Price = p.Price,
                               Count = p.Count,
                               ProductCategoryId = p.ProductCategoryId,
                               ProductCategoryName = pc.Name
                           };


            var products = await _modelQueryExecutor.ToListAsync(query, cancellationToken);

            if (products.Any() is false)
                return NotFound();

            return Success(products);
        }
    }
}
