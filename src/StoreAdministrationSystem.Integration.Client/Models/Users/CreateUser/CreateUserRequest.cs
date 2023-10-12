namespace StoreAdministrationSystem.Integration.Client.Models;

public sealed class CreateUserRequest
{
    /// <summary>
    /// Email пользователя
    /// </summary>
    public string Email { get; init; } = null!;
    
    /// <summary>
    /// Пароль пользователя
    /// </summary>
    public string Password { get; init; } = null!;

    /// <summary>
    ///Логин пользователя
    /// </summary>
    public string Login { get; init; } = null!;

    /// <summary>
    /// Флаг, указывающий, является ли пользователь администратором
    /// </summary>
    public bool IsAdmin { get; init; }
}
