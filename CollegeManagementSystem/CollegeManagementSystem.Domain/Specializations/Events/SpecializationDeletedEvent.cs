using SharedKernel;

namespace CollegeManagementSystem.Domain.Specializations.Events;

public sealed class SpecializationDeletedEvent : IDomainEvent
{
    public required SpecializationId SpecializationId { get; init; }
}
