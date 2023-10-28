using Microsoft.AspNetCore.Mvc;
using StoreAdministrationSystem.Application;
using StoreAdministrationSystem.Application.Commands.Users;
using StoreAdministrationSystem.Application.Commands.Users.AddProductInUserSchoppingCartCommand;
using StoreAdministrationSystem.Application.Commands.Users.CreateUserCommand;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.Application.Queries;
using StoreAdministrationSystem.Application.Queries.Users.GetPagedUserListQuery;
using StoreAdministrationSystem.Application.Queries.Users.GetUserByIdQuery;
using System.ComponentModel.DataAnnotations;

namespace StoreAdministrationSystem.Api.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UserController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Page<GetPagedUserListQuery.UserReference>), 200)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetPagedUserListAsync(
        [FromServices] IQueryExecutor queryExecutor,
        [FromQuery] int offset = 0,
        [FromQuery][Range(0, 100)] int count = 100,
        [FromQuery] Guid? userId = null,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await queryExecutor.ExecuteAsync<
            GetPagedUserListQuery,
            GetPagedUserListQuery.Results.SuccessResult,
            GetPagedUserListQuery.Results.FailResult>(new()
            {
                Count = count,
                Offset = offset,
                UserId = userId
            }, cancellationToken);

        return queryResult.Match(
            success => Ok(success.Users),
            fail => fail.Code switch
            {
                _ => InternalServerError()
            });
    }

    [HttpGet("{userId:guid}")]
    [ProducesResponseType(typeof(GetUserByIdQuery.UserReference), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetUserByIdAsync(
        [FromServices] IQueryExecutor queryExecutor,
        [FromQuery] Guid userId,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await queryExecutor.ExecuteAsync<
            GetUserByIdQuery,
            GetUserByIdQuery.Results.SuccessResult,
            GetUserByIdQuery.Results.FailResult>(new()
            {
                UserId = userId
            }, cancellationToken);

        return queryResult.Match(
            success => Ok(success.User),
            fail => fail.Code switch
            {
                ApplicationErrorCodes.USER_NOT_FOUND => NotFound(fail.Code, fail.Message),
                _ => InternalServerError()
            });
    }

    [HttpPost()]
    [ProducesResponseType(200)]
    [ProducesResponseType(409)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> CreateUserAsync(
        [FromServices] ICommandExecutor commandExecutor,
        [FromBody] CreateUserModel model,
        CancellationToken cancellationToken = default)
    {
        var commandResult = await commandExecutor.ExecuteAsync<
            CreateUserCommand,
            CreateUserCommand.Results.SuccessResult,
            CreateUserCommand.Results.FailResult>(new()
            {
                Login = model.Login,
                Password = model.Password,
                Email = model.Email,
                IsAdmin = model.IsAdmin
            }, cancellationToken);

        return commandResult.Match(
            success => Ok(),
            fail => fail.Code switch
            {
                ApplicationErrorCodes.USER_ALREADY_EXIST => Conflict(fail.Code, fail.Message),
                _ => InternalServerError()
            });
    }

    [HttpPost("{userId:guid}/add-product/{productId:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(422)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> AddProductAsync(
        [FromServices] ICommandExecutor commandExecutor,
        [FromRoute] Guid userId,
        [FromRoute] Guid productId,
        [FromQuery][Required][Range(1, 1000)] int productCount,
        CancellationToken cancellationToken = default)
    {
        var commandResult = await commandExecutor.ExecuteAsync<
            AddProductInUserSchoppingCartCommand,
            AddProductInUserSchoppingCartCommand.Results.SuccessResult,
            AddProductInUserSchoppingCartCommand.Results.FailResult>(new()
            {
                ProductCount = productCount,
                ProductId = productId,
                UserId = userId
            }, cancellationToken);

        return commandResult.Match(
            success => Ok(),
            fail => fail.Code switch
            {
                ApplicationErrorCodes.USER_NOT_FOUND => NotFound(fail.Code, fail.Message),
                ApplicationErrorCodes.PRODUCT_NOT_FOUND => NotFound(fail.Code, fail.Message),
                ApplicationErrorCodes.NOT_ENOUGHT_PRODUCT => UnprocessableEntity(fail.Code, fail.Message),
                _ => InternalServerError()
            });
    }

    [HttpPost("{userId:guid}/delete-product/{productId:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(422)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> DeleteProductAsync(
        [FromServices] ICommandExecutor commandExecutor,
        [FromRoute] Guid userId,
        [FromRoute] Guid productId,
        [FromQuery][Required][Range(1, 1000)] int productCount,
        CancellationToken cancellationToken = default)
    {
        var commandResult = await commandExecutor.ExecuteAsync<
            DeleteProductFromSchoppingCartPositionCommand,
            DeleteProductFromSchoppingCartPositionCommand.Results.SuccessResult,
            DeleteProductFromSchoppingCartPositionCommand.Results.FailResults>(new()
            {
                UserId = userId,
                ProductId = productId,
                ProductCount = productCount
            }, cancellationToken);

        return commandResult.Match(
            success => Ok(),
            fail => fail.Code switch
            {
                ApplicationErrorCodes.USER_NOT_FOUND => NotFound(fail.Code, fail.Message),
                ApplicationErrorCodes.PRODUCT_NOT_FOUND => NotFound(fail.Code, fail.Message),
                ApplicationErrorCodes.USER_SCHOPPING_CART_POSITION_NOT_FOUND => UnprocessableEntity(fail.Code, fail.Message),
                _ => InternalServerError()
            });
    }


    #region Models

    public sealed class CreateUserModel
    {
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;
        public string Login { get; init; } = null!;
        public bool IsAdmin { get; init; }
    }

    #endregion

}
