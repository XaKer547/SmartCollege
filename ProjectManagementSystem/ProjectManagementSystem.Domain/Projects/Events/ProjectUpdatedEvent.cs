namespace ProjectManagementSystem.Domain.Projects.Events;

public sealed class ProjectUpdatedEvent
{
    public Project Project { get; init; }
}
