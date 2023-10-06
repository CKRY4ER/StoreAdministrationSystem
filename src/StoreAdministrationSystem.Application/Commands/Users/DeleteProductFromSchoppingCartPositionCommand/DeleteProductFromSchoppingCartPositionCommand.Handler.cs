using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.DataAccess.Repositories.Products;
using StoreAdministrationSystem.DataAccess.Repositories.Users;

namespace StoreAdministrationSystem.Application.Commands.Users;

public sealed partial class DeleteProductFromSchoppingCartPositionCommand
{
    public sealed class Handler : ICommandHandler<
        DeleteProductFromSchoppingCartPositionCommand,
        Results.SuccessResult,
        Results.FailResults>
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRespository;

        public Handler(IUserRepository userRepository,
            IProductRepository productRespository)
        {
            _userRepository = userRepository;
            _productRespository = productRespository;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResults>> Handle(DeleteProductFromSchoppingCartPositionCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);

            if (user is null)
                return UserNotFound();

            var product = await _productRespository.GetByIdAsync(request.ProductId, cancellationToken);

            if (product is null)
                return ProductNotFound();

            var position = user.ShoppingCartPositions.FirstOrDefault(position => position.ProductId == request.ProductId);

            if (position is null)
                return SchoppingCartPositionNotFound();

            if (position.ProductCount > request.ProductCount)
                user.ReduceProductAmmountInPosition(position, request.ProductCount);
            else
                user.DeletePosition(position);

            await _userRepository.SaveAsync(user, cancellationToken);

            return Success();
        }
    }
}
