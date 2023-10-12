namespace StoreAdministrationSystem.Integration.Client.Models;

public sealed class GetPagedUserListResponse
{
    /// <summary>
    /// ID пользователя
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Логин пользователя
    /// </summary>
    public string Login { get; init; } = null!;

    /// <summary>
    /// Email пользователя
    /// </summary>
    public string Email { get; init; } = null!;

    /// <summary>
    /// Флаг, указывающий, является ли данный пользователь администратором
    /// </summary>
    public bool IsAdmin { get; init; }

    /// <summary>
    /// Дата создания пользователя
    /// </summary>
    public DateTimeOffset CreateDate { get; init; }

    /// <summary>
    /// Дата обновления пользователя
    /// </summary>
    public DateTimeOffset UpdateDate { get; init; }
}
