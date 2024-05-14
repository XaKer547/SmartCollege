using SharedKernel;

namespace CollegeManagementSystem.Domain.Disciplines.Events;

public sealed class DisciplineCreatedEvent : IDomainEvent
{
    public required Discipline Discipline { get; init; }
}
