using MediatR;

namespace CollegeManagementSystem.Domain.Employees.Events;

public sealed record EmployeeUpdatedEvent : INotification
{
    public Employee Employee { get; init; }
}
