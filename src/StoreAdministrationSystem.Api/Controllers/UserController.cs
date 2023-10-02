﻿using Microsoft.AspNetCore.Mvc;
using StoreAdministrationSystem.Application;
using StoreAdministrationSystem.Application.Framework;
using StoreAdministrationSystem.Application.Queries;
using StoreAdministrationSystem.Application.Queries.Users;
using System.ComponentModel.DataAnnotations;

namespace StoreAdministrationSystem.Api.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UserController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Page<GetPagedUserListQuery.Results.UserReference>), 200)]
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
    [ProducesResponseType(typeof(GetUserByIdQuery.Results.UserReference), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetUserByIdQuery(
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

}
