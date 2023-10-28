using Microsoft.Extensions.Logging;
using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.DataAccess.Repositories.ProductCategories;
using StoreAdministrationSystem.DataAccess.Repositories.Products;
using StoreAdministrationSystem.Domain.Products;

namespace StoreAdministrationSystem.Application.Commands.Products.CreateProductCommand;

public sealed partial class CreateProductCommand
{
    public sealed class Handler : ICommandHandler<
        CreateProductCommand,
        Results.SuccessResult,
        Results.FailResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ILogger _logger;

        public Handler(IProductRepository productRepository,
            ILogger<Handler> logger,
            IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _logger = logger;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByName(request.ProductName, cancellationToken);

            if (product is not null)
                return AlreadyExists();

            var productCategory = await _productCategoryRepository.GetByidAsync(request.ProductCategoryId, cancellationToken);

            if (productCategory is null)
            {
                _logger.LogWarning($"Couldn't find the category when creating the product. CategoryId: {request.ProductCategoryId}");
                return ProductCategoryNotFound();
            }

            var newProduct = new Product(request.ProductName, request.Description,
                request.Price, request.ProductPicture, request.Parameters, productCategory);

            await _productRepository.SaveAsync(newProduct, cancellationToken);

            return Success();
        }
    }
}
