using SharedKernel;

namespace ProjectManagementSystem.Domain.Projects.Events;

public sealed class ProjectDeletedEvent : IDomainEvent
{
    public ProjectId ProjectId { get; init; }
}