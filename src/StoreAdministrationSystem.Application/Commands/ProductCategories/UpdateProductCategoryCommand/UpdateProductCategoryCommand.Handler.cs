using Microsoft.Extensions.Logging;
using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.DataAccess.Repositories.ProductCategories;

namespace StoreAdministrationSystem.Application.Commands.ProductCategories;

public sealed partial class UpdateProductCategoryCommand
{
    public sealed class Handler : ICommandHandler<
        UpdateProductCategoryCommand,
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

        public async Task<OneOf<Results.SuccessResult, Results.FailResult>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetByidAsync(request.ProductCategoryId, cancellationToken);

            if (productCategory is null)
                return NotFound();

            productCategory.UpdateInformation(request.Name);

            await _productCategoryRepository.SaveAsync(productCategory, cancellationToken);

            return Success();
        }
    }
}
