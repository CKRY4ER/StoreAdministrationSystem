using Microsoft.AspNetCore.Mvc;
using StoreAdministrationSystem.Application;
using StoreAdministrationSystem.Application.Commands.ProductCategories;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.Application.Queries;
using StoreAdministrationSystem.Application.Queries.ProductCategories;
using System.ComponentModel.DataAnnotations;

namespace StoreAdministrationSystem.Api.Controllers;

[ApiController]
[Route("api/product-categories")]
public class ProductCategoryController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Page<GetPagedProductCategoriesListQuery.Results.ProductCatogoryReference>), 200)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetPagedProductCategoriesListAsync(
        [FromServices] IQueryExecutor queryExecutor,
        [FromQuery] int offset = 0,
        [FromQuery][Range(0, 100)] int count = 100,
        [FromQuery] string? name = null,
        [FromQuery] Guid? productCategoryId = null,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await queryExecutor.ExecuteAsync<
            GetPagedProductCategoriesListQuery,
            GetPagedProductCategoriesListQuery.Results.SuccessResult,
            GetPagedProductCategoriesListQuery.Results.FailResults>(new()
            {
                Offset = offset,
                Count = count,
                Name = name,
                ProductCategoryId = productCategoryId
            }, cancellationToken);

        return queryResult.Match(
            success => Ok(success.ProductCategories),
            fail => fail.Code switch
            {
                _ => InternalServerError()
            });
    }

    [HttpPost()]
    [ProducesResponseType(200)]
    [ProducesResponseType(409)]
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

    [HttpGet("list")]
    [ProducesResponseType(typeof(GetProductCategoriesListQuery.Results.ProductCategoryReference[]), 200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetProductCategoriesListAsync(
        [FromServices] IQueryExecutor queryExecutor,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await queryExecutor.ExecuteAsync<
            GetProductCategoriesListQuery,
            GetProductCategoriesListQuery.Results.SuccessResult,
            GetProductCategoriesListQuery.Results.FailResult>(new(), cancellationToken);

        return queryResult.Match(
            success => Ok(success.ProductCategories),
            fail => fail.Code switch
            {
                ApplicationErrorCodes.PRODUCT_CATEGORY_NOT_FOUND => NoContent(),
                _ => InternalServerError()
            });
    }

    [HttpPatch("{categoryId:guid}/update")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateProductCategoryAsync(
        [FromServices] ICommandExecutor commandExecutor,
        [FromRoute] Guid categoryId,
        [FromQuery] string name,
        CancellationToken cancellationToken = default)
    {
        var commandResult = await commandExecutor.ExecuteAsync<
            UpdateProductCategoryCommand,
            UpdateProductCategoryCommand.Results.SuccessResult,
            UpdateProductCategoryCommand.Results.FailResult>(new()
            {
                ProductCategoryId = categoryId,
                Name = name,
            }, cancellationToken);

        return commandResult.Match(
            success => NoContent(),
            fail => fail.Code switch
            {
                ApplicationErrorCodes.PRODUCT_CATEGORY_NOT_FOUND => NotFound(fail.Code, fail.Message),
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
