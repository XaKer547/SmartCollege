using SharedKernel;

namespace CollegeManagementSystem.Domain.Employees.Events;

public sealed class EmployeeDeletedEvent : IDomainEvent
{
    public required EmployeeId EmployeeId { get; init; }
}
