namespace StoreAdministrationSystem.Application.Queries;

public sealed class Page<T> where T : notnull
{
    public Page()
    {
        Values = Array.Empty<T>();
    }

    public long Total { get; internal set; }
    public int Offset { get; internal set; }
    public int Count { get; internal set; }
    public IReadOnlyCollection<T> Values { get; set; }

    public static Page<T> Empty(int offset)
        => new()
        {
            Offset = offset,
            Count = 0,
            Total = 0L,
            Values = Array.Empty<T>()
        };
}
