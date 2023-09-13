using Microsoft.Extensions.Logging;
using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.DataAccess.Repositories.ProductCategories;
using StoreAdministrationSystem.Domain.ProductCategories;

namespace StoreAdministrationSystem.Application.Commands.CreateProductCategoryProductCommand;

public sealed partial class CreateProductCategoryCommand
{
    public sealed class Handler : ICommandHandler<
        CreateProductCategoryCommand,
        Results.SuccessResult,
        Results.FailResult>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ILogger _logger;

        public Handler(IProductCategoryRepository productCategoryRepository,
            ILogger<Handler> logger)
        {
            _productCategoryRepository = productCategoryRepository;
            _logger = logger;
        }

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetByNameAsync(request.ProductCategoryName, cancellationToken);

            if (productCategory is not null)
                return AlreadyExists();

            try
            {
                var newProductCategory = new ProductCategory(request.ProductCategoryName);

                await _productCategoryRepository.SaveAsync(newProductCategory, cancellationToken);

                return Success();
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Error saving a new product category.\nMassege: {ex.Message}");
                return InternalError();
            }
        }
    }
}
