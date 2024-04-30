using SharedKernel;

namespace CollegeManagementSystem.Domain.Specializations.Events;

public sealed class SpecializationCreatedEvent : IDomainEvent
{
    public required Specialization Specialization { get; set; }
}
