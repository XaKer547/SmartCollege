using SharedKernel;

namespace CollegeManagementSystem.Domain.Disciplines.Events;

public sealed record DisciplineUpdatedEvent : IDomainEvent
{
    public Discipline Discipline { get; init; }
}
