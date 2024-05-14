using SharedKernel;

namespace ProjectManagementSystem.Domain.Projects.Events;

public sealed class ProjectCreatedEvent : IDomainEvent
{
    public Project Project { get; init; }
}
