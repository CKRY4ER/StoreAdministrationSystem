using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.DataAccess.Repositories.Products;
using StoreAdministrationSystem.DataAccess.Repositories.Users;
using StoreAdministrationSystem.Domain.Users;

namespace StoreAdministrationSystem.Application.Commands.Users.AddProductInUserSchoppingCartCommand;

public sealed partial class AddProductInUserSchoppingCartCommand
{
    public sealed class Handler : ICommandHandler<
        AddProductInUserSchoppingCartCommand,
        Results.SuccessResult,
        Results.FailResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public Handler(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(AddProductInUserSchoppingCartCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (product is null)
                return ProductNotFound();

            if (product.Count < request.ProductCount)
                return NotEnoughtProduct();

            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (user is null)
                return UserNotFound();

            var schoppingCartPosition = user.ShoppingCartPositions.FirstOrDefault(position => position.ProductId == request.ProductId);

            if (schoppingCartPosition is null)
            {
                var newPostiton = new UserSchoppingCartPosition(request.ProductId, request.ProductCount);

                user.AddSchoppingCartPositon(newPostiton);
            }
            else
                user.AddProductInSchoppingCartPosition(schoppingCartPosition, request.ProductCount);

            await _userRepository.SaveAsync(user, cancellationToken);

            return Success();
        }
    }
}
