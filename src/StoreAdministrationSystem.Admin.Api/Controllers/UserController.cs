using Microsoft.AspNetCore.Mvc;
using StoreAdministrationSystem.Integration.Client;
using StoreAdministrationSystem.Integration.Client.Models;

namespace StoreAdministrationSystem.Admin.Api.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UserController : ApiControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(PageResponse<GetPagedUserListResponse>), 200)]
    [ProducesResponseType(500)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetPagedUserListAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        GetPagedUserListRequest request,
        CancellationToken cancellation = default)
    {
        var response = await client.GetPagedUserListAsync(request, cancellation);

        if (response.IsSuccessStatusCode)
            return Ok(response.Content);

        if (response.Error is not null)
            throw response.Error;

        return InternalServerError();
    }

    [HttpGet("{userId:guid}")]
    [ProducesResponseType(typeof(GetUserByIdResponse), 200)]
    [ProducesResponseType(404)]
    [ProducesErrorResponseType(typeof(ProblemDetails))]
    public async Task<IActionResult> GetUserByIdAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        [FromRoute] Guid userId,
        CancellationToken cancellationToken = default)
    {
        var response = await client.GetUserBydAsync(userId, cancellationToken);

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
    public async Task<IActionResult> CreateAdminUserAsync(
        [FromServices] IStoreAdministrationServiceClient client,
        CreateAdminUserRequest request,
        CancellationToken cancellationToken = default)
    {
        var response = await client.CreateUserAsync(new()
        {
            Email = request.Email,
            Password = request.Password,
            Login = request.Login,
            IsAdmin = true
        }, cancellationToken);

        if (response.IsSuccessStatusCode)
            return Ok();

        if (response.Error is not null)
            throw response.Error;

        return InternalServerError();
    }

    #region Models

    public sealed class CreateAdminUserRequest
    {
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;
        public string Login { get; init; } = null!;
    }

    #endregion
}
