namespace PanKunik.CleanArchitecture.BuildingBlocks;

public abstract class AggregateRoot<TId, TValue>
    : Entity<TId, TValue>
    where TId : EntityId<TValue>
    where TValue : notnull
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        ArgumentNullException.ThrowIfNull(domainEvent);
        _domainEvents.Add(domainEvent);
    }

    public IReadOnlyCollection<IDomainEvent> PullDomainEvents()
    {
        var events = _domainEvents.ToArray();
        _domainEvents.Clear();
        return events;
    }

    protected AggregateRoot(TId id)
        : base(id) { }
}