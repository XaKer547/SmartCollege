using SharedKernel;

namespace CollegeManagementSystem.Domain.Students.Events;

public sealed class StudentUpdatedEvent : IDomainEvent
{
    public required Student Student { get; init; }
}
