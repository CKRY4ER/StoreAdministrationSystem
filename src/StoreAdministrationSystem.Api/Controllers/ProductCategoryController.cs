using Microsoft.AspNetCore.Mvc;
using StoreAdministrationSystem.Application;
using StoreAdministrationSystem.Application.Commands.CreateProductCategoryProductCommand;
using StoreAdministrationSystem.Application.Framework;

namespace StoreAdministrationSystem.Api.Controllers;

[ApiController]
[Route("api/product-categories")]
public class ProductCategoryController : ApiControllerBase
{
    [HttpPost("create")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> CreateProductCategoryAsync(
        [FromServices] ICommandExecutor commandExecutor,
        [FromBody] CreateProductCategoryRequest request, 
        CancellationToken cancellationToken = default)
    {
        var commandResult = await commandExecutor.ExecuteAsync<
            CreateProductCategoryCommand,
            CreateProductCategoryCommand.Results.SuccessResult,
            CreateProductCategoryCommand.Results.FailResult>(new()
            {
                ProductCategoryName = request.Name
            }, cancellationToken);

        return commandResult.Match(
            success => Ok(),
            fail => fail.Code switch
            {
                ApplicationErrorCodes.PRODUCT_CATEGORY_ALREADY_EXISTS => Conflict(fail.Code, fail.Message),
                _ => InternalServerError()
            });
    }

    #region Models

    public sealed class CreateProductCategoryRequest
    {
        public string Name { get; init; } = null!;
    }

    #endregion
}
