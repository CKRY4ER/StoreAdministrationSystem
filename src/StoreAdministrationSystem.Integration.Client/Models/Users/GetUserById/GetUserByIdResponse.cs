namespace StoreAdministrationSystem.Integration.Client.Models;

public sealed class GetUserByIdResponse
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
    /// Флаг, указывающий, является ли пользоваатель администратором
    /// </summary>
    public bool IsAdmin { get; init; }

    /// <summary>
    /// Позииции карзины пользователя
    /// </summary>
    public IEnumerable<UserSchoppingCartPosition> SchoppingCartPositionList { get; init; } = null!;

    /// <summary>
    /// Список документов пользователя
    /// </summary>
    public IEnumerable<UserDocument> DocumentList { get; init; } = null!;

    /// <summary>
    /// Дата создания пользователя
    /// </summary>
    public DateTimeOffset CreateDate { get; init; }

    /// <summary>
    /// Дата обновления пользователя
    /// </summary>
    public DateTimeOffset UpdateDate { get; init; }
}
public sealed class UserSchoppingCartPosition
{
    /// <summary>
    /// ID продукта
    /// </summary>
    public Guid ProductId { get; init; }

    /// <summary>
    /// Кол-во продукта в позиции
    /// </summary>
    public int ProductCount { get; init; }

    /// <summary>
    /// Полная цена позиции
    /// </summary>
    public decimal TotalPrice { get; init; }
}

public sealed class UserDocument
{
    /// <summary>
    /// ID документа
    /// </summary>
    public Guid DocumentId { get; init; }

    /// <summary>
    /// Тип документа
    /// </summary>
    public string DocumentType { get; init; } = null!;
}
