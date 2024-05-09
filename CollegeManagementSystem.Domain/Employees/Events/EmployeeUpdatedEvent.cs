using SharedKernel;

namespace CollegeManagementSystem.Domain.Employees.Events;

public sealed record EmployeeUpdatedEvent : IDomainEvent
{
    public Employee Employee { get; init; }
}
