namespace StoreAdministrationSystem.Domain;

public abstract class Aggregate
{
    protected Aggregate() { }

    protected Aggregate(Guid aggregateId)
    {
        AggregateId = aggregateId;
    }

    public Guid AggregateId { get; private set; }
}
