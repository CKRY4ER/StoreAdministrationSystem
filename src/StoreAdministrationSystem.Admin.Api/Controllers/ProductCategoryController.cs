﻿using Microsoft.AspNetCore.Mvc;
using StoreAdministrationSystem.Integration.Client;
using StoreAdministrationSystem.Integration.Client.Models;
using System.ComponentModel.DataAnnotations;

namespace StoreAdministrationSystem.Admin.Api.Controllers;

[ApiController]
[Route("api/product-categories")]
public sealed class ProductCategoryController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<GetPagedProductCategoriesListResponse>), 200)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetPagedProductCategoriesListAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        [FromQuery] int offset = 0,
        [FromQuery][Range(0, 100)] int count = 100,
        [FromQuery] string? name = null,
        [FromQuery] Guid? productCategoryId = null,
        CancellationToken cancellationToken = default)
    {
        var response = await client.GetPagedProductCategoriesListAsync(new()
        {
            Offset = offset,
            Count = count,
            Name = name,
            ProductCategoryId = productCategoryId
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
    public async Task<IActionResult> CreateProductCategoryAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        CreateProductCategoryRequest request, 
        CancellationToken cancellationToken = default)
    {
        var response = await client.CreateProductCategoryAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
            return Ok();

        if (response.Error is not null)
            throw response.Error;

        return InternalServerError();
    }

    [HttpPatch("{categoryId:guid}/update")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateProductCategoryAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        [FromRoute] Guid categoryId,
        [FromQuery] string name,
        CancellationToken cancellationToken = default)
    {
        var response = await client.UpdateProductCategoryAsync(categoryId, name, cancellationToken);

        if (response.IsSuccessStatusCode)
            return Ok();

        if (response.Error is not null)
            throw response.Error;

        return InternalServerError();
    }
}
