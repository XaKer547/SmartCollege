using SharedKernel;

namespace CollegeManagementSystem.Domain.Employees.Events;

public sealed class EmployeeDeletedEvent : IDomainEvent
{
    public EmployeeDeletedEvent(string email)
    {
        Email = email;
    }

    public string Email { get; init; }
}
