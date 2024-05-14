using SharedKernel;

namespace CollegeManagementSystem.Domain.Groups.Events;

public sealed record GroupUpdatedEvent : IDomainEvent
{
    public required Group Group { get; init; }
}
