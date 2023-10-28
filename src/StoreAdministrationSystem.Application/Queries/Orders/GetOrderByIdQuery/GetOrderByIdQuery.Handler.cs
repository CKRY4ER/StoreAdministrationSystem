using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.ReadModel;
using StoreAdministrationSystem.ReadModel.Orders;
using StoreAdministrationSystem.ReadModel.Products;
using System.Data;

namespace StoreAdministrationSystem.Application.Queries.Orders.GetOrderByIdQuery;

public sealed partial class GetOrderByIdQuery
{
    public sealed class Handler : IQueryHandler<
        GetOrderByIdQuery,
        Results.SuccessResult,
        Results.FailResult>
    {
        private readonly IReadModelQueryExecutor _modelQueryExecutor;
        private readonly IReadModelQueryProvider<OrderModelItem> _orderModelProvider;
        private readonly IReadModelQueryProvider<OrderPositionModelItem> _orderPositionModelProvider;
        private readonly IReadModelQueryProvider<ProductModelItem> _productModelProvider;

        public Handler(IReadModelQueryExecutor modelQueryExecutor,
            IReadModelQueryProvider<OrderModelItem> orderModelProvider,
            IReadModelQueryProvider<OrderPositionModelItem> orderPositionModelProvider,
            IReadModelQueryProvider<ProductModelItem> productModelProvider)
        {
            _modelQueryExecutor = modelQueryExecutor;
            _orderModelProvider = orderModelProvider;
            _orderPositionModelProvider = orderPositionModelProvider;
            _productModelProvider = productModelProvider;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var orderQuery = from o in _orderModelProvider.Queryable
                             where o.OrderId == request.OrderId
                             select new
                             {
                                 OrderId = o.OrderId,
                                 UserId = o.UserId,
                                 OrderStatus = o.OrderStatus,
                                 TotalPrice = o.TotalPrice,
                                 UpdateDate = o.UpdateDate,
                                 CreateDate = o.CreateDate
                             };

            var order = await _modelQueryExecutor.FirstOrDefaultAsync(orderQuery, cancellationToken);

            if (order is null)
                return NotFound();

            var orderPositionQuery = from op in _orderPositionModelProvider.Queryable
                                     where op.OrderId == request.OrderId
                                     join p in _productModelProvider.Queryable on op.ProductId equals p.ProductId
                                     select new OrderPositionReference
                                     {
                                         ProductId = op.ProductId,
                                         ProductName = p.ProductName,
                                         Count = op.Count,
                                         PositionPrice = op.PositionPrice
                                     };

            var orderPosition = await _modelQueryExecutor.ToListAsync(orderPositionQuery, cancellationToken);

            return Success(new()
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                OrderStatus = order.OrderStatus,
                OrderPositions = orderPosition,
                TotalPrice = order.TotalPrice, 
                UpdateDate = order.UpdateDate,
                CreateDate = order.CreateDate
            });
        }
    }
}
