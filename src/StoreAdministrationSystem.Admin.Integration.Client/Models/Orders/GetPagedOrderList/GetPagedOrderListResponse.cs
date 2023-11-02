namespace StoreAdministrationSystem.Admin.Integration.Client.Models;

public sealed class GetPagedOrderListResponse
{
    /// <summary>
    /// ID заказа
    /// </summary>
    public Guid OrderId { get; init; }

    /// <summary>
    /// ID пользователя, который создал заказ
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Полная стоимость заказа
    /// </summary>
    public decimal TotalPrice { get; init; }

    /// <summary>
    /// Статус заказа
    /// </summary>
    public string Status { get; init; } = null!;

    /// <summary>
    /// Дата создания заказа
    /// </summary>
    public DateTimeOffset CreateDate { get; init; }

    /// <summary>
    /// Дата обновления заказа
    /// </summary>
    public DateTimeOffset UpdateDate { get; init; }
}
