using SharedKernel;

namespace CollegeManagementSystem.Domain.Groups.Events;

public sealed record GroupCreatedEvent : IDomainEvent
{
    public required Group Group { get; init; }
}
