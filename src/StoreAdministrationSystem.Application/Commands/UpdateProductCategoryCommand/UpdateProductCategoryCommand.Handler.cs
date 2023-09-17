using Microsoft.Extensions.Logging;
using OneOf;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.DataAccess.Repositories.ProductCategories;

namespace StoreAdministrationSystem.Application.Commands.UpdateProductCategoryCommand;

public sealed partial class UpdateProductCategoryCommand
{
    public sealed class Handler : ICommandHandler<
        UpdateProductCategoryCommand,
        Results.SuccessResult,
        Results.Failresult>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ILogger _logger;

        public Handler(IProductCategoryRepository productCategoryRepository,
            ILogger<Handler> logger)
        {
            _productCategoryRepository = productCategoryRepository;
            _logger = logger;
        }

        public async Task<OneOf<Results.SuccessResult, Results.Failresult>> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetByidAsync(request.ProductCategoryId, cancellationToken);

            if (productCategory is null)
                return NotFound();

            return Success();
        }
    }
}
