using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.ReadModel;
using StoreAdministrationSystem.ReadModel.Orders;

namespace StoreAdministrationSystem.Application.Queries.Orders;

public sealed partial class GetPagedOrderListQuery
{
    public sealed class Handler : IQueryHandler<
        GetPagedOrderListQuery,
        Results.SuccessResult,
        Results.FailResult>
    {
        private readonly IReadModelQueryExecutor _modelQueryExecutor;
        private readonly IReadModelQueryProvider<OrderModelItem> _orderModelProvider;

        public Handler(IReadModelQueryExecutor modelQueryExecutor,
            IReadModelQueryProvider<OrderModelItem> orderModelProvider)
        {
            _orderModelProvider = orderModelProvider;
            _modelQueryExecutor = modelQueryExecutor;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(GetPagedOrderListQuery request, CancellationToken cancellationToken)
        {
            var query = _orderModelProvider.Queryable;

            if (request.OrderId is not null)
                query = query.Where(order => order.OrderId == request.OrderId);

            if (request.UserId is not null)
                query = query.Where(order => order.UserId == request.UserId);

            var total = await _modelQueryExecutor.CountAsync(query, cancellationToken);

            if (total == 0)
                return Success(Page<Results.OrderReference>.Empty(request.Offset));

            var resultQuery = from order in query
                              select new Results.OrderReference
                              {
                                  OrderId = order.OrderId,
                                  UserId = order.UserId,
                                  TotalPrice = order.TotalPrice,
                                  Status = order.OrderStatus,
                                  CreateDate = order.CreateDate,
                                  UpdateDate = order.UpdateDate
                              };

            resultQuery = resultQuery
                .OrderByDescending(order => order.UpdateDate)
                .Skip(request.Offset)
                .Take(request.Count);

            var orders = await _modelQueryExecutor.ToListAsync(resultQuery, cancellationToken);

            return Success(orders.AsPage(total, request.Offset));
        }
    }
}
