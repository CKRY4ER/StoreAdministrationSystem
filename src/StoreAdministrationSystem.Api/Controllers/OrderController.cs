using Microsoft.AspNetCore.Mvc;
using StoreAdministrationSystem.Application;
using StoreAdministrationSystem.Application.Commands.Orders;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.Application.Queries.Orders;
using System.ComponentModel.DataAnnotations;

namespace StoreAdministrationSystem.Api.Controllers;

[ApiController]
[Route("api/orders")]
public sealed class OrderController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(GetPagedOrderListQuery.Results.OrderReference[]), 200)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetPagedOrderListAsync(
        [FromServices] IQueryExecutor queryExecutor,
        [FromQuery] int offset = 0,
        [FromQuery][Range(0, 100)] int count = 100,
        [FromQuery] Guid? orderid = null,
        [FromQuery] Guid? userId = null,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await queryExecutor.ExecuteAsync<
            GetPagedOrderListQuery,
            GetPagedOrderListQuery.Results.SuccessResult,
            GetPagedOrderListQuery.Results.FailResult>(new()
            {
                Offset = offset,
                Count = count,
                OrderId = orderid,
                UserId = userId
            }, cancellationToken);

        return queryResult.Match(
            success => Ok(success.Orders),
            fail => fail.Code switch
            {
                _ => InternalServerError()
            });
    }

    [HttpGet("{orderId:guid}")]
    [ProducesResponseType(typeof(GetOrderByIdQuery.Results.OrderReference), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetOrderByIdAsync(
        [FromServices] IQueryExecutor queryExecutor,
        [FromRoute] Guid orderId,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await queryExecutor.ExecuteAsync<
            GetOrderByIdQuery,
            GetOrderByIdQuery.Results.SuccessResult,
            GetOrderByIdQuery.Results.FailResult>(new()
            {
                OrderId = orderId
            },
            cancellationToken);

        return queryResult.Match(
            success => Ok(success.Order),
            fail => fail.Code switch
            {
                ApplicationErrorCodes.ORDER_NOT_FOUND => NotFound(fail.Code, fail.Message),
                _ => InternalServerError()
            });
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(422)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> CreateOrderAsync(
        [FromServices] ICommandExecutor commandExecutor,
        [FromQuery][Required] Guid userId,
        CancellationToken cancellationToken = default)
    {
        var commandResult = await commandExecutor.ExecuteAsync<
            CreateOrderCommand,
            CreateOrderCommand.Results.SuccessResult,
            CreateOrderCommand.Results.FailResult>(new()
            {
                UserId = userId
            }, cancellationToken);

        return commandResult.Match(
            success => Ok(),
            fail => fail.Code switch
            {
                ApplicationErrorCodes.USER_SCHOPPING_CART_EMPTY => UnprocessableEntity(fail.Code, fail.Message),
                ApplicationErrorCodes.USER_NOT_FOUND => UnprocessableEntity(fail.Code, fail.Message),
                ApplicationErrorCodes.NOT_ENOUGHT_PRODUCT => UnprocessableEntity(fail.Code, fail.Message),
                _ => InternalServerError()
            });
    }
}
