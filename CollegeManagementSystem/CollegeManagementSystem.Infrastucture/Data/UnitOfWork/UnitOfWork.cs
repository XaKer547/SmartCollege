﻿using CollegeManagementSystem.Domain.Services;
using SharedKernel;

namespace CollegeManagementSystem.Infrastucture.Data.UnitOfWork;

public sealed class UnitOfWork(CollegeManagementSystemDbContext context, IDomainEventDispatcher eventDispatcher) : IUnitOfWork
{
    private readonly CollegeManagementSystemDbContext context = context;
    private readonly IDomainEventDispatcher eventDispatcher = eventDispatcher;
    public ICollegeManagementSystemRepository Repository => context;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            return;

        var domainEventEntities = context.ChangeTracker.Entries<Entity<EntityId>>()
            .Select(e => e.Entity)
            .Where(e => e.ContainsEvents())
            .ToArray();

        foreach (var entity in domainEventEntities)
        {
            foreach (var @event in entity.Events)
                await eventDispatcher.DispatchAsync(@event);
        }
    }
}