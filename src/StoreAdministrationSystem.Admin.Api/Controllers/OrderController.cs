﻿using Microsoft.AspNetCore.Mvc;
using StoreAdministrationSystem.Integration.Client;
using StoreAdministrationSystem.Integration.Client.Models;

namespace StoreAdministrationSystem.Admin.Api.Controllers;

[ApiController]
[Route("api/orders")]
public sealed class OrderController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<GetPagedOrderListResponse>), 200)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetPagedOrderListAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        GetPagedOrderListRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await client.GetPagedOrderListAsync(request, cancellationToken);

        if (response.IsSuccessStatusCode)
            return Ok(response.Content);

        if (response.Error is not null)
            throw response.Error;

        return InternalServerError();
    }

    [HttpGet("{orderId:guid}")]
    [ProducesResponseType(typeof(GetOrderByIdResponse), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetOrderByIdAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        [FromRoute] Guid orderId,
        CancellationToken cancellationToken = default)
    {
        var response = await client.GetorderByIdAsync(orderId, cancellationToken);

        if (response.IsSuccessStatusCode)
            return Ok(response.Content);

        if (response.Error is not null)
            throw response.Error;

        return InternalServerError();
    }
}
