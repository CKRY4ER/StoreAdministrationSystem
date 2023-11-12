using Microsoft.AspNetCore.Mvc;
using StoreAdministrationSystem.Application;
using StoreAdministrationSystem.Application.Commands.Products;
using StoreAdministrationSystem.Application.Commands.Products.CreateProductCommand;
using StoreAdministrationSystem.Application.Commands.Products.UpdateProductCommand;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.Application.Queries;
using StoreAdministrationSystem.Application.Queries.Products;
using StoreAdministrationSystem.Application.Queries.Products.GetPagedProductListQuery;
using StoreAdministrationSystem.Application.Queries.Products.GetProductListQuery;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace StoreAdministrationSystem.Api.Controllers;

[ApiController]
[Route("api/products")]
public sealed class ProductController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Page<GetPagedProductListQuery.ProductReference>), 200)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetPagedProductListAsync(
        [FromServices] IQueryExecutor queryExecutor,
        [FromQuery] int offset = 0,
        [FromQuery][Range(0, 100)] int count = 100,
        [FromQuery] string? productName = null,
        [FromQuery] Guid? productId = null,
        [FromQuery] Guid? productCategoryid = null,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await queryExecutor.ExecuteAsync<
            GetPagedProductListQuery,
            GetPagedProductListQuery.Results.SuccessResult,
            GetPagedProductListQuery.Results.FailResult>(new()
            {
                Offset = offset,
                Count = count,
                ProductCategoryId = productCategoryid,
                ProductId = productId,
                ProductName = productName
            }, cancellationToken);

        return queryResult.Match(
            succes => Ok(succes.Products),
            fail => fail.Code switch
            {
                _ => InternalServerError()
            });
    }

    //[HttpGet("list")]
    //[ProducesResponseType(typeof(GetProductListQuery.ProductReference[]), 200)]
    //[ProducesResponseType(204)]
    //[ProducesResponseType(500)]
    //[ProducesErrorResponseType(typeof(ProblemDetails))]
    //public async Task<IActionResult> GetProductListAsync(
    //    [FromServices] IQueryExecutor queryExecutor,
    //    [FromQuery] Guid productCategoryId,
    //    CancellationToken cancellationToken = default)
    //{
    //    var queryResult = await queryExecutor.ExecuteAsync<
    //        GetProductListQuery,
    //        GetProductListQuery.Results.SuccessResult,
    //        GetProductListQuery.Results.FailResults>(new()
    //        {
    //            ProductCategoryid = productCategoryId
    //        }, cancellationToken);

    //    return queryResult.Match(
    //        success => Ok(success.Products),
    //        fail => fail.Code switch
    //        {
    //            ApplicationErrorCodes.PRODUCT_NOT_FOUND => NotFound(fail.Code, fail.Message),
    //            _ => InternalServerError()
    //        });
    //}

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(409)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> CreateProductAsync(
        [FromServices] ICommandExecutor commandExecutor,
        [FromBody] CreateProductModel model,
        CancellationToken cancellationToken = default)
    {
        var commandResult = await commandExecutor.ExecuteAsync<
            CreateProductCommand,
            CreateProductCommand.Results.SuccessResult,
            CreateProductCommand.Results.FailResult>(new()
            {


            }, cancellationToken);

        return commandResult.Match(
            success => Ok(),
            fail => fail.Code switch
            {
                ApplicationErrorCodes.PRODUCT_ALREADY_EXIST => Conflict(fail.Code, fail.Message),
                ApplicationErrorCodes.PRODUCT_CATEGORY_NOT_FOUND => NotFound(fail.Code, fail.Message),
                _ => InternalServerError()
            });
    }

    [HttpPatch("{productId:guid}/update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateProductAsync(
        [FromServices] ICommandExecutor commandExecutor,
        Guid productId,
        [FromBody] UpdateProductModel model,
        CancellationToken cancellationToken = default)
    {
        var commandResult = await commandExecutor.ExecuteAsync<
            UpdateProductCommand,
            UpdateProductCommand.Results.SuccessResult,
            UpdateProductCommand.Results.FailResult>(new()
            {
                ProductId = productId,
                ProductCategoryId = model.ProductCategoryId,
                ProductName = model.ProductName,
                Description = model.Description,
                Price = model.Price,
                ProductPicture = model.ProductPicture,
                Parameters = model.Parameters
            }, cancellationToken);

        return commandResult.Match(
            success => Ok(),
            fail => fail.Code switch
            {
                ApplicationErrorCodes.PRODUCT_NOT_FOUND => NotFound(fail.Code, fail.Message),
                ApplicationErrorCodes.PRODUCT_CATEGORY_NOT_FOUND => NotFound(fail.Code, fail.Message),
                _ => InternalServerError()
            });
    }


    #region Models

    public sealed class CreateProductModel
    {
        public string ProductName { get; init; } = null!;
        public string Description { get; init; } = null!;
        public decimal Price { get; init; }
        public Uri ProductPicture { get; init; } = null!;
        public Dictionary<string, string> Parameters { get; init; } = null!;
        public Guid ProductCategoryId { get; init; }
    }

    public sealed class UpdateProductModel
    {
        public string ProductName { get; init; } = null!;
        public string Description { get; init; } = null!;
        public decimal Price { get; init; }
        public Uri ProductPicture { get; init; } = null!;
        public Dictionary<string, string> Parameters { get; init; } = null!;
        public Guid ProductCategoryId { get; init; }
    }

    #endregion
}
