using Microsoft.Extensions.Logging;
using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.DataAccess.Repositories.Orders;
using StoreAdministrationSystem.DataAccess.Repositories.Products;
using StoreAdministrationSystem.DataAccess.Repositories.Users;
using StoreAdministrationSystem.Domain.Orders;

namespace StoreAdministrationSystem.Application.Commands.Orders.CreateOrderCommand;

public sealed partial class CreateOrderCommand
{
    public sealed class Handler : ICommandHandler<
        CreateOrderCommand,
        Results.SuccessResult,
        Results.FailResult>
    {
        private readonly IUserRepository _userReposiotry;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;

        public Handler(IUserRepository userReposiotry,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            ILogger<Handler> logger)
        {
            _userReposiotry = userReposiotry;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userReposiotry.GetByIdAsync(request.UserId, cancellationToken);

            if (user is null)
                return UserNotFound();

            if (user.ShoppingCartPositions.Any() is false)
                return UserSchoppingCartIsEmpty();

            var orderPositionList = new List<OrderPosition>();

            decimal orderTotalPrice = 0M;

            foreach(var userSchoppingCartPosition in user.ShoppingCartPositions)
            {
                var product = await _productRepository.GetByIdAsync(userSchoppingCartPosition.ProductId, cancellationToken);

                if (product!.Count < userSchoppingCartPosition.ProductCount)
                    return NotEnoughtProduct();

                var userShoppingCartPostionTotalPrice = userSchoppingCartPosition.Product.Price * userSchoppingCartPosition.ProductCount;
                orderTotalPrice += userShoppingCartPostionTotalPrice;

                orderPositionList.Add(new(userSchoppingCartPosition.ProductId,
                    userSchoppingCartPosition.Product.Price,
                    userSchoppingCartPosition.ProductCount,
                    userShoppingCartPostionTotalPrice));
            }

            var order = new Order(user.AggregateId, orderTotalPrice, orderPositionList);

            user.ClearShoppingCartPosition();

            await _userReposiotry.SaveAsync(user, cancellationToken);
            await _orderRepository.SaveAsync(order, cancellationToken);

            return Success();
        }
    }
}
