using SharedKernel;

namespace CollegeManagementSystem.Domain.Groups.Events;

public sealed record GroupDeletedEvent : IDomainEvent
{
    public required GroupId GroupId { get; init; }
}
