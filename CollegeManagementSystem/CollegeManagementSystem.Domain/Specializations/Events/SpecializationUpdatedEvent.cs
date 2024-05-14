using SharedKernel;

namespace CollegeManagementSystem.Domain.Specializations.Events;

public sealed class SpecializationUpdatedEvent : IDomainEvent
{
    public required Specialization Specialization { get; init; }
}
