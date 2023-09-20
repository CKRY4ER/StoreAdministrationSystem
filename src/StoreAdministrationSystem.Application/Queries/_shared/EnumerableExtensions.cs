namespace StoreAdministrationSystem.Application.Queries;

public static class EnumerableExtensions
{
    public static Page<T> AsPage<T>(this IEnumerable<T> values, long total, int offset) where T : notnull
        => new()
        {
            Total = total,
            Offset = offset,
            Count = values.Count(),
            Values = (IReadOnlyCollection<T>)values
        };
}
