namespace StoreAdministrationSystem.Integration.Client.Models;

public sealed class PageResponse<T>
    where T : class 
{
    /// <summary>
    /// Общее кол-во элементов
    /// </summary>
    public int Total { get; init; }

    /// <summary>
    /// Возвращенное кол-во элементов
    /// </summary>
    public int Count { get; init; }

    /// <summary>
    /// Пропущенно элементов
    /// </summary>
    public int Offset { get; init; }

    /// <summary>
    /// Коллекция элементов
    /// </summary>
    public IEnumerable<T> Values { get; init; } = null!;
}
