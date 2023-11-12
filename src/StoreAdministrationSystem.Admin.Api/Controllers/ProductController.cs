using Microsoft.AspNetCore.Mvc;
using StoreAdministrationSystem.Integration.Client;
using StoreAdministrationSystem.Integration.Client.Models;
using System.ComponentModel.DataAnnotations;

namespace StoreAdministrationSystem.Admin.Api.Controllers;

[ApiController]
[Route("api/products")]
public sealed class ProductController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<GetPagedProductListResponse>), 200)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetPagedProductListAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        [FromQuery] int offset = 0,
        [FromQuery][Range(0, 100)] int count = 100,
        [FromQuery] string? productName = null,
        [FromQuery] Guid? productId = null,
        [FromQuery] Guid? productCategoryId = null,
        CancellationToken cancellationToken = default)
    {
        var response = await client.GetPagedProductListAsync(new()
        {
            Offset = offset,
            Count = count,
            ProductName = productName,
            ProdcutId = productId,
            ProductCategoryId = productCategoryId,
        }, cancellationToken);

        if (response.IsSuccessStatusCode)
            return Ok(response.Content);

        if (response.Error is not null)
            throw response.Error;

        return InternalServerError();
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(409)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> CreateProductAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        CreateProductRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await client.CreateProductAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
            return Ok();

        if (response.Error is not null)
            throw response.Error;

        return InternalServerError();
    }

    [HttpPatch("{productId:guid}/update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateProductAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        Guid productId,
        UpdateProductRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await client.UpdateProductAsync(productId, request, cancellationToken);

        if (response.IsSuccessStatusCode)
            return Ok();

        if (response.Error is not null)
            throw response.Error;

        return InternalServerError();
    }
}
