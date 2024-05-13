using System.ComponentModel.DataAnnotations.Schema;

namespace SharedKernel;

public abstract class Entity<TEntityId>
    where TEntityId : class
{
    public TEntityId Id { get; protected set; }
    public bool Deleted { get; protected set; }

    private readonly List<IDomainEvent> _events = [];
    protected void AddEvent(IDomainEvent domainEvent) => _events.Add(domainEvent);
    public bool ContainsEvents() => _events.Count != 0;

    [NotMapped]
    public IDomainEvent[] Events => [.. _events];
}