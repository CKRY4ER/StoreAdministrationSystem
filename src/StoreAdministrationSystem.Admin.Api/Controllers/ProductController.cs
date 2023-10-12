using Microsoft.AspNetCore.Mvc;
using StoreAdministrationSystem.Integration.Client;
using StoreAdministrationSystem.Integration.Client.Models;

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
        GetPagedProductListRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await client.GetPagedProductListAsync(request, cancellationToken);

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
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateProductAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        UpdateProductRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await client.UpdateProductAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
            return Ok();

        if (response.Error is not null)
            throw response.Error;

        return InternalServerError();
    }
}
