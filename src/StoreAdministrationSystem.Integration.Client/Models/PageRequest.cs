namespace StoreAdministrationSystem.Integration.Client.Models;

public abstract class PageRequest
{
    public int Offset { get; init; }
    public int Count { get; init; }
}
