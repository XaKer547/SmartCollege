using ProjectManagementSystem.Domain.Services;
using ProjectManagementSystem.Infrastucture.Common;
using SharedKernel;

namespace ProjectManagementSystem.Infrastucture.Data.UnitOfWork
{
    public class UnitOfWork(ProjectManagementSystemDbContext context) : IUnitOfWork
    {
        private readonly ProjectManagementSystemDbContext context = context;
        public IProjectManagementSystemRepository Repository => context;

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                return;

            var domainEventEntities = context.ChangeTracker.Entries<Entity>()
                .Select(e => e.Entity)
                .Where(e => e.ContainsEvents())
                .ToArray();

            await context.SaveChangesAsync(cancellationToken);

            foreach (var entity in domainEventEntities)
            {
                foreach (var @event in entity.Events)
                {
                    //await eventDispatcher.DispatchAsync(@event);
                }
            }
        }
    }
}
