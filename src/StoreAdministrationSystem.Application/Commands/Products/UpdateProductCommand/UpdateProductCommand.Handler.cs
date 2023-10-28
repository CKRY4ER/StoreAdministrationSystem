using Microsoft.Extensions.Logging;
using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.DataAccess.Repositories.ProductCategories;
using StoreAdministrationSystem.DataAccess.Repositories.Products;

namespace StoreAdministrationSystem.Application.Commands.Products.UpdateProductCommand;

public sealed partial class UpdateProductCommand
{
    public sealed class Handler : ICommandHandler<
        UpdateProductCommand,
        Results.SuccessResult,
        Results.FailResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ILogger _logger;

        public Handler(IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository,
            ILogger<Handler> logger)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _logger = logger;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

            if (product is null)
                return NotFound();

            var productCategory = await _productCategoryRepository.GetByidAsync(request.ProductCategoryId, cancellationToken);

            if (productCategory is null)
            {
                _logger.LogWarning($"Could not get the product category when changing the product. ProductCategoryId: {request.ProductCategoryId}");
                return CategoryNotFound();
            }

            product.UpdateInformation(request.ProductName, request.Description, request.Price,
                request.ProductPicture, request.Parameters, productCategory);

            await _productRepository.SaveAsync(product, cancellationToken);

            return Success();
        }
    }
}
