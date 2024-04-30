using SharedKernel;

namespace CollegeManagementSystem.Domain.Disciplines.Events;

public sealed class DisciplineDeletedEvent : IDomainEvent
{
    public required DisciplineId DisciplineId { get; init; }
}
