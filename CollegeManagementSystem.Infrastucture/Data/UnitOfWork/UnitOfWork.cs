using CollegeManagementSystem.Domain.Services;
using SharedKernel;

namespace CollegeManagementSystem.Infrastucture.Data.UnitOfWork;

public sealed class UnitOfWork(CollegeManagementSystemDbContext context, IDomainEventDispatcher eventDispatcher) : IUnitOfWork
{
    private readonly CollegeManagementSystemDbContext _context = context;
    private readonly IDomainEventDispatcher _eventDispatcher = eventDispatcher;
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            return;

        var domainEventEntities = _context.ChangeTracker.Entries < Entity<EntityId>()
            .Select(e => e.Entity)
            .Where(e => e.ContainsEvents())
            .ToArray();

        foreach (var entity in domainEventEntities)
        {
            foreach (var @event in entity.Events)
                await _eventDispatcher.DispatchAsync(@event);
        }
    }
}