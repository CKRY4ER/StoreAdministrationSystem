using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.ReadModel;
using StoreAdministrationSystem.ReadModel.ProductCategories;
using StoreAdministrationSystem.ReadModel.Products;
using System.Linq.Expressions;

namespace StoreAdministrationSystem.Application.Queries.Products.GetPagedProductListQuery;

public sealed partial class GetPagedProductListQuery
{
    public sealed class Handler : IQueryHandler<
        GetPagedProductListQuery,
        Results.SuccessResult,
        Results.FailResult>
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

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetPagedProductListQuery request, CancellationToken cancellationToken)
        {
            var query = _productModelProvider.Queryable;

            if (request.ProductName is not null)
                query = query.Where(product => product.ProductName == request.ProductName);

            if (request.ProductCategoryId is not null)
                query = query.Where(product => product.ProductCategoryId == request.ProductCategoryId);

            if (request.ProductId is not null)
                query = query.Where(product => product.ProductId == request.ProductId);

            var total = await _modelQueryExecutor.CountAsync(query, cancellationToken);

            if (total == 0)
                return Success(Page<ProductReference>.Empty(request.Offset));

            var resultQuery = from p in query
                              join pc in _productCategoryModelProvider.Queryable on p.ProductCategoryId equals pc.ProductCategoryId
                              select new ProductReference
                              {
                                  ProductId = p.ProductId,
                                  ProductName = p.ProductName,
                                  Price = p.Price,
                                  Count = p.Count,
                                  ProductCategoryId = p.ProductCategoryId,
                                  ProductCategoryName = pc.Name,
                                  UpdateDate = p.UpdateDate,
                                  CreateDate = p.CreateDate
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
