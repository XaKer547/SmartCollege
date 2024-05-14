using SharedKernel;

namespace CollegeManagementSystem.Domain.Employees.Events;

public sealed class EmployeeCreatedEvent : IDomainEvent
{
    public required Employee Employee { get; init; }
}
