namespace SharedKernel;

public abstract class Entity
{
    public bool Deleted { get; private set; }

    private readonly List<IDomainEvent> _events = [];
    protected void AddEvent(IDomainEvent domainEvent) => _events.Add(domainEvent);
}
